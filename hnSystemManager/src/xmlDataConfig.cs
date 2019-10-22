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

        public SystemManager mSystemManager;

        public xmlDataConfig()
        {
            debugMode = true;
            mSystemManager = new SystemManager();
        }

        public class SystemManager
        {
            public SystemManager()
            {
                startVisible = true;
                saveLogfile = false;
                NetworkManagerServerMode = true;
                NetworkManagerServerPort = 55000;
            }

            [XmlElement("saveLogfile")]
            public bool saveLogfile { get; set; }

            [XmlElement("controlServerPort")]
            public int controlServerPort { get; set; }

            [XmlElement("startVisible")]
            public bool startVisible { get; set; }

            [XmlElement("NetworkManagerServerMode")]
            public bool NetworkManagerServerMode { get; set; }

            [XmlElement("NetworkManagerServerPort")]
            public int NetworkManagerServerPort { get; set; }
        }
    }
}
