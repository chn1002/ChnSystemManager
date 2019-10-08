using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class ClientCommunication : IDisposable
{
    private bool disposed;
    public delegate void NetworkReceive(string data);
    public static event NetworkReceive OnNetworkReceive = null;

    // ManualResetEvent instances signal completion.  
    private static ManualResetEvent connectDone =
        new ManualResetEvent(false);
    private static ManualResetEvent sendDone =
        new ManualResetEvent(false);
    private static ManualResetEvent receiveDone =
        new ManualResetEvent(false);

    private Socket clientSocket;
    private bool streamType;
    private int timeout = 2000;

    public ClientCommunication(bool stream, int socketTimeout)
    {
        streamType = stream;
        timeout = socketTimeout;
    }

    ~ClientCommunication()
    {
        Dispose(false);
    }

    // State object for receiving data from remote device.  
    public class StateObject
    {
        // Client socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 256*10;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();
    }

    // The response from the remote device.  
    private String response = String.Empty;

    public bool StartClient(string hostName, int port)
    {
        // Connect to a remote device.  
        try
        {
            IPAddress ipAddress = IPAddress.Parse(hostName);
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

            // Create a Protocol/IP socket.  
            if(streamType)
            {
                clientSocket = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                var result = clientSocket.BeginConnect(remoteEP, null, null);

                bool success = result.AsyncWaitHandle.WaitOne(timeout, true);

                if(success)
                {
                    clientSocket.EndConnect(result);
                    return true;
                }
                else
                {
                    clientSocket.Close();
                    throw new SocketException(10060); // Connection timed out.
                }
            }
            else
            {
                clientSocket = new Socket(ipAddress.AddressFamily,
                    SocketType.Dgram, ProtocolType.Udp);

                // Connect to the remote endpoint.  
                clientSocket.Connect(remoteEP);
            }

            // Write the response to the console.  
            Console.WriteLine("Response received : {0}", response);

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            return false;
        }
    }

    public void StopClient()
    {
        if (clientSocket != null && clientSocket.Connected)
        {
            // Release the socket.  
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
    }

    public void Receive()
    {
        try
        {
            // Create the state object.  
            StateObject state = new StateObject();
            state.workSocket = clientSocket;

            // Begin receiving the data from the remote device.  
            clientSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReceiveCallback), state);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    private void ReceiveCallback(IAsyncResult ar)
    {
        try
        {
            // Retrieve the state object and the client socket   
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            Socket client = state.workSocket;

            // Read data from the remote device.  
            int bytesRead = client.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There might be more data, so store the data received so far.  
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                if(OnNetworkReceive != null)
                {
                    OnNetworkReceive(state.sb.ToString());

                    state.sb.Clear();
                }

                // Get the rest of the data.  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            else
            {
                // All the data has arrived; put it in response.  
                if (state.sb.Length > 1)
                {
                    response = state.sb.ToString();
                }
                // Signal that all bytes have been received.  
                receiveDone.Set();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public bool Send(String data)
    {
        // Convert the string data to byte data using ASCII encoding.  
        byte[] byteData = Encoding.ASCII.GetBytes(data);
        bool connected = false;

        
        if(streamType 
            && (clientSocket.Available == 0)
            && (clientSocket.Poll(1000, SelectMode.SelectRead)))
        {
            connected = false;
        }
        else
        {
            connected = true;
        }

        if(connected)
        {
            // Begin sending the data to the remote device.  
            clientSocket.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), clientSocket);

            return true;
        }
        else
        {
            return false;
        }
    }

    private void SendCallback(IAsyncResult ar)
    {
        try
        {
            // Retrieve the socket from the state object.  
            Socket client = (Socket)ar.AsyncState;

            // Complete sending the data to the remote device.  
            int bytesSent = client.EndSend(ar);
            Console.WriteLine("Sent {0} bytes to server.", bytesSent);

            // Signal that all bytes have been sent.  
            sendDone.Set();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (this.disposed)
            return;

        if (disposing)
        {
            clientSocket.Dispose();
        }

        this.disposed = true;
    }

}
