using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace hnSystemManager.src
{
    [XmlRoot("chnProjectConfig")]
    public class xmlDataConfig
    {
        [XmlAttribute]
        public string programName;

        [XmlAttribute]
        public bool debugMode;

        [XmlAttribute]
        public int MaxNetworkEntry = 3;

        public SystemManager mSystemManager;
        public NetworkSystemEntry[] NetworkSystem;

        public xmlDataConfig()
        {
            debugMode = true;
            mSystemManager = new SystemManager();
            NetworkSystemEntry TmpNetworkSystem = new NetworkSystemEntry();
            NetworkSystem = new NetworkSystemEntry[MaxNetworkEntry];
            NetworkSystem[0] = TmpNetworkSystem;
        }

        public class SystemManager
        {
            public SystemManager()
            {
                startVisible = true;
                saveLogfile = false;
                socketTimeout = 2;
                controlServerPort = 50000;
                NetworkManagerServerMode = true;
                NetworkManagerServerPort = 55000;
            }

            [XmlElement("saveLogfile")]
            public bool saveLogfile { get; set; }

            [XmlElement("socketTimeout")]
            public int socketTimeout { get; set; }

            [XmlElement("controlServerPort")]
            public int controlServerPort { get; set; }

            [XmlElement("startVisible")]
            public bool startVisible { get; set; }

            [XmlElement("NetworkManagerServerMode")]
            public bool NetworkManagerServerMode { get; set; }

            [XmlElement("NetworkManagerServerPort")]
            public int NetworkManagerServerPort { get; set; }
        }

        public class NetworkSystemEntry
        {
            public NetworkSystemEntry()
            {
                enable = false;
                NetworkAddress = "127.0.0.1";
                port = 12000;
                Description = "Item Description";
            }

            [XmlElement("enable")]
            public bool enable { get; set; }

            [XmlElement("NetworkAddress")]
            public string NetworkAddress { get; set; }

            [XmlElement("port")]
            public int port { get; set; }

            [XmlElement("Description")]
            public string Description { get; set; }
        }
    }
}
