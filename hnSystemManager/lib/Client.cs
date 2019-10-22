using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Jerrryfighter.MultipleSocket
{
    class Client
    {
        #region Properties
        public string ID
        {
            get;
            private set;
        }

        public IPEndPoint EndPoint
        {
            get;
            private set;
        }
        #endregion

        public Socket sck;
        #region Constructor
        public Client(Socket accepted)
        {
            sck = accepted;
            ID = Guid.NewGuid().ToString();
            EndPoint = (IPEndPoint)sck.RemoteEndPoint;
            sck.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);
        }
        #endregion

        #region Callback Method
        void callback(IAsyncResult ar)
        {
            try
            {
                sck.EndReceive(ar);

                byte[] buf = new byte[8192];

                int rec = sck.Receive(buf, buf.Length, 0);

                if (rec <= 0)
                {
                    Close();

                    if (Disconnected != null)
                    {
                        Disconnected(this);
                    }
                }

                if (rec < buf.Length)
                {
                    Array.Resize<byte>(ref buf, rec);
                }
                
                if (Received != null)
                {
                    Received(this, buf);
                }

                sck.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);
            }
            catch(SocketException se)
            {
                Console.WriteLine(se.Message.ToString());
                Close();

                switch (se.SocketErrorCode)
                {
                    case SocketError.ConnectionAborted:
                    case SocketError.ConnectionReset:
                        Close();

                        if (Disconnected != null)
                        {
                            Disconnected(this);
                        }
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Close();

                if (Disconnected != null)
                {
                    Disconnected(this);
                }
            }
        }
        #endregion

        #region Close
        public void Close()
        {
            sck.Close();
            sck.Dispose();
        }

        #endregion

        #region Delegate
        public delegate void ClientReceivedHandler(Client sender, byte[] data);
        public event ClientReceivedHandler Received;

        public delegate void ClientDisconnectedHandler(Client sender);        
        public event ClientDisconnectedHandler Disconnected;
        #endregion

        public void SendMessage(byte[] data)
        {
            sck.Send(data, 0, data.Length, SocketFlags.None);
        }
    }
}
