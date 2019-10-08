using hnSystemManager.src;
using hnSystemManager.src.util;
using System;
using System.IO;
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

        private const string configFileName = "/SystemManager.xml";
        private static networkTestUtil ntTest;

        class networkTestEntry
        {
            internal bool networkTestResult;
            internal bool networkPortTestResult;
            internal bool networkApplicationTestResult;
            internal ClientCommunication client;

            internal void stopClient()
            {
                if(client != null)
                {
                    client.StopClient();
                }
            }
        }

        private static networkTestEntry[] ntEntry;

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

            ntEntry = new networkTestEntry[gXMLDataConfig.NetworkSystem.Length];

            for (int i = 0; i < gXMLDataConfig.NetworkSystem.Length; i++)
            {
                ntEntry[i] = new networkTestEntry();
                ntEntry[i].client = new ClientCommunication(true, gXMLDataConfig.mSystemManager.socketTimeout);
            }

            if (gXMLDataConfig.mSystemManager.NetworkManagerServerMode)
            {
                mNetworkManagerSystemProcess = new NetworkSystemProcess(mMainSystemManagerForm,
                    gXMLDataConfig.mSystemManager.NetworkManagerServerPort);
                mNetworkManagerSystemProcess.startServer();
                mNetworkManagerSystemProcess.NetworkDataReceivedHandler += NetworkManagerDataReceivedHandler;
            }
            else
            {
                mMainSystemManagerForm.InitializeNetwork();
            }

            mLogProc.DebugLog("System Start");
            Application.Run(mMainSystemManagerForm);
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

            foreach(networkTestEntry ntClient in ntEntry)
            {
                ntClient.stopClient();
            }

            mLogProc.DebugLog("System Shutdown");

            Application.ExitThread();
            Environment.Exit(0);
        }

        /**
         * System Client ICMP Test
         * Argument: index - Systme Client Index
         */
        internal static bool systemClientICMPTest(int index)
        {
            string ipAddress;
            bool resultICMP = false ;

            if (GetXmlDataConfig().NetworkSystem.Length < index)
                return false;

            NetworkSystemEntry nsE = GetXmlDataConfig().NetworkSystem[index];

            if (nsE != null)
            {
                ipAddress = nsE.NetworkAddress;
                resultICMP = ntTest.testICMP(ipAddress);
            }

            ntEntry[index].networkTestResult = resultICMP;

            return resultICMP;
        }

        /**
         * System Client Entry Port Scan function 
         * Argument: index - Systme Client Index
         */
        internal static bool systemClientPortScan(int index)
        {
            string ipAddress;
            int port;
            bool resultPortScan= false;

            if (GetXmlDataConfig().NetworkSystem.Length < index)
            {
                ntEntry[index].networkPortTestResult = false;
                return false;
            }

            NetworkSystemEntry nsE = GetXmlDataConfig().NetworkSystem[index];

            if (nsE != null)
            {
                ipAddress = nsE.NetworkAddress;
                port = nsE.port;
                resultPortScan = ntTest.ConnectTest(ipAddress, port);
            }

            ntEntry[index].networkPortTestResult = resultPortScan;

            return resultPortScan;
        }

        /**
         * System Client Entry Scan function 
         * Argument: index - Systme Client Index
         */
        internal static bool systemClientScan(int index)
        {
            string ipAddress;
            int port;
            bool resultClientScan = false;

            if (GetXmlDataConfig().NetworkSystem.Length < index)
            {
                ntEntry[index].networkApplicationTestResult = false;
                return false;
            }

            NetworkSystemEntry nsE = GetXmlDataConfig().NetworkSystem[index];

            if (nsE != null)
            {
                ipAddress = nsE.NetworkAddress;
                port = nsE.port;
                resultClientScan = ntEntry[index].client.StartClient(ipAddress, port);
            }

            ntEntry[index].networkApplicationTestResult = resultClientScan;
            return resultClientScan;
        }

        /**
         * System Client Entry Command function 
         * Argument: index - Systme Client Index
         *           command - System Command
         */
        internal static bool sendSystemCommand(int index, string command)
        {
            string ipAddress;
            int port;
            bool resultClientScan = false;

            if (GetXmlDataConfig().NetworkSystem.Length < index)
            {
                ntEntry[index].networkApplicationTestResult = false;
                return false;
            }

            NetworkSystemEntry nsE = GetXmlDataConfig().NetworkSystem[index];

            if (nsE != null)
            {
                ipAddress = nsE.NetworkAddress;
                port = nsE.port;
                resultClientScan = ntEntry[index].client.Send(command + "\n");
            }

            return resultClientScan;
        }

        /**
         * System Client Entry Connection Check function 
         * Argument: index - Systme Client Index
         */
        internal static bool getSystemConnectionClient(int index)
        {
            if(ntEntry[index].networkTestResult == true &&
                ntEntry[index].networkPortTestResult == true &&
                ntEntry[index].networkApplicationTestResult == true)
            {
                return true;
            }

            return false;
        }
    }
}
