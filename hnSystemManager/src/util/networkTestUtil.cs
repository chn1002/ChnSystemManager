using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace hnSystemManager.src.util
{
    class networkTestUtil
    {
        private readonly int timeout = 1000; // 1000 ms

        internal bool testICMP(string ipaddr)
        {
            Ping pingSender = new Ping();

            PingReply replay = pingSender.Send(ipaddr,timeout);

            if(replay.Status == IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal bool ConnectTest(string ip, int port)
        {
            bool result = false; Socket socket = null;

            try {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontLinger, false);
                IAsyncResult ret = socket.BeginConnect(ip, port, null, null);
                result = ret.AsyncWaitHandle.WaitOne(timeout, true);
            }
            catch { }
            finally {
                if (socket != null)
                {
                    socket.Close();
                }
            }
            return result;
        }
    }
}
