using hnSystemManager.src;
using hnSystemManager.src.util;
using Jerrryfighter.MultipleSocket;
using System;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using static hnSystemManager.src.xmlDataConfig;

namespace hnSystemManager
{
    static class Program
    {
        public static xmlDataConfig gXMLDataConfig;
        public static LogProcess mLogProc;

        static xmlDataProcess gXMLProcess;
        static MainSystemManagerForm mMainSystemManagerForm;
        static NetworkSystemProcess mNetworkSystemProcess;
        static NetworkSystemProcess mNetworkManagerSystemProcess;
        static Listener listener = null;

        private const string configFileName = "/SystemManager.xml";
        private static networkTestUtil ntTest;

        [STAThread]
        static void Main()
        {
            gXMLProcess = new xmlDataProcess();
            xmlConfigStart(false);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mMainSystemManagerForm = new MainSystemManagerForm();
            mNetworkSystemProcess = new NetworkSystemProcess(mMainSystemManagerForm, 
                gXMLDataConfig.mSystemManager.controlServerPort);
            mNetworkSystemProcess.startServer();
            mNetworkSystemProcess.NetworkDataReceivedHandler += NetworkDataReceivedHandler;
            ntTest = new networkTestUtil();

            mLogProc = new LogProcess(gXMLDataConfig.mSystemManager.saveLogfile, mMainSystemManagerForm);

            listener = new Listener(gXMLDataConfig.mSystemManager.NetworkManagerServerPort);
            listener.SocketAccepted += new Listener.SocketAcceptedHandler(listener_SocketAccepted);

            listener.Start("0.0.0.0");

            mLogProc.DebugLog("System Start");
            Application.Run(mMainSystemManagerForm);
        }

        private static void listener_SocketAccepted(Socket e)
        {
            Client client = new Client(e);
            client.Received += new Client.ClientReceivedHandler(client_Received);
            client.Disconnected += new Client.ClientDisconnectedHandler(client_Disconnected);

            mMainSystemManagerForm.ListenerAccepted(client, e.Handle.ToString());

        }

        private static void client_Received(Client sender, byte[] data)
        {
            mMainSystemManagerForm.ListenerRecevied(sender, data);

        }

        private static void client_Disconnected(Client sender)
        {
            mMainSystemManagerForm.ListenerDisconnect(sender);
        }

        private static void NetworkManagerDataReceivedHandler(string Data)
        {
            mLogProc.DebugLog("Network Manager Data Received:" + Data + "::" + Data.Length);
        }

        private static void NetworkDataReceivedHandler(string Data)
        {
            mLogProc.DebugLog("Network Data Received:" + Data + "::" + Data.Length);
            remoteClientSendData("Test:"+ Data);
        }

        private static void remoteClientSendData(string data)
        {
            string ntBuffer = data;
            ntBuffer = ntBuffer.Replace("\0", "");

            mNetworkSystemProcess.NetworkWrite(ntBuffer);
        }

        private static void xmlConfigStart(bool save)
        {
            gXMLDataConfig = new xmlDataConfig { programName = "SystemManager" };

            string fileName = AppDomain.CurrentDomain.BaseDirectory + configFileName;
            FileInfo configFile = new System.IO.FileInfo(fileName);

            if (save)
            {
                gXMLProcess.XMLCreate(gXMLDataConfig, fileName);

                return;
            }

            if (configFile.Exists)
            {
                gXMLDataConfig = gXMLProcess.XMLDeserialize(fileName, gXMLDataConfig);
            }
            else
            {
                gXMLProcess.XMLCreate(gXMLDataConfig, fileName);
            }
        }

        public static xmlDataConfig GetXmlDataConfig()
        {
            return gXMLDataConfig;
        }

        public static void systemShutdown()
        {
            if(mNetworkSystemProcess != null)
            {
                mNetworkSystemProcess.stopServer();
                mLogProc.DebugLog("Remote Control Server Stop");
            }

            mLogProc.DebugLog("System Shutdown");

            Application.ExitThread();
            Environment.Exit(0);
        }

    }
}
