using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace hnSystemManager.src
{
    class NetworkSystemProcess
    {
        private bool networkEnable = false;
        private MainSystemManagerForm mMainsystemForm;
        private int serverPort = 50000;
        private TcpListener listener;
        private Thread networkClientThread;
        List<Socket> connectedClients = new List<Socket>();
        private int ClientNumber = 0;

        public delegate void NetworkDataReceivedHandlerFunc(string receiveData);
        public NetworkDataReceivedHandlerFunc NetworkDataReceivedHandler;

        public NetworkSystemProcess(MainSystemManagerForm mainSystemForm, int port)
        {
            mMainsystemForm = mainSystemForm;

            networkClientThread = new Thread(NetworkThread);
            networkClientThread.IsBackground = true;

            if (port != 0)
            {
                serverPort = port;
            }

            listener = new TcpListener(IPAddress.Any, serverPort);
            listener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        }

        internal void NetworkWrite(string data)
        {
            if (networkEnable == false)
            {
                return;
            }

            byte[] bDts = Encoding.ASCII.GetBytes(data + "\0");
            //        byte[] bDts = Encoding.UTF8.GetBytes(data + "\0");

            for (int i = connectedClients.Count - 1; i >= 0; i--)
            {
                Socket socket = connectedClients[i];
                if(!socket.Connected)
                {
                    System.Diagnostics.Debug.WriteLine("Socket is not Connected : " + i);
                    connectedClients.RemoveAt(i);
                    continue;
                }

                NetworkStream ns = new NetworkStream(socket);

                System.Diagnostics.Debug.WriteLine("Network Write : " + i + ":" + data + ": " + connectedClients.Count);

                try
                {
                    ns.Write(bDts, 0, bDts.Length);
                }
                catch
                {
                    try { socket.Dispose(); } catch { }
                    connectedClients.RemoveAt(i);
                    ClientNumber--;
                }
            }

            return;
        }

        internal void startServer()
        {
            networkEnable = true;

            listener.Start();
            networkClientThread.Start();
        }

        internal void stopServer()
        {
            networkEnable = false;

            if (listener != null) listener.Stop();
            if (networkClientThread != null) networkClientThread.Abort();
        }

        private void NetworkThread()
        {
            while (networkEnable)
            {
                try
                {
                    TcpClient tcClient = listener.AcceptTcpClient();

                    string info = tcClient.Client.RemoteEndPoint.ToString();

                    connectedClients.Add(tcClient.Client);
                    Thread ReceiveThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                    ReceiveThread.Start(tcClient);
                }
                catch
                {

                }
            }
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            string bufferincmessage;

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }

                //message has successfully been received
                ASCIIEncoding encoder = new ASCIIEncoding();

                bufferincmessage = encoder.GetString(message, 0, bytesRead);

                NetworkDataReceivedHandler?.Invoke(bufferincmessage);
            }
        }

    }
}
