using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace hnSystemManager.src
{
    class xmlDataProcess : IDisposable
    {
        // Config
        private XmlSerializer serialzer = null;
        private FileStream stream = null;
        private bool disposed;

        // Create
        public void XMLCreate(xmlDataConfig config, string filepath)
        {
            XmlSerializer writer = new XmlSerializer(typeof(xmlDataConfig));
            using (StreamWriter sw = new StreamWriter(new FileStream(filepath, FileMode.Create), Encoding.UTF8))
            {
                writer.Serialize(sw, config);
            }

        }

        ~xmlDataProcess()
        {
            this.Dispose(false);
        }

        // Save
        public void XMLSerialize(xmlDataConfig config, string filepath)
        {
            serialzer = new XmlSerializer(typeof(xmlDataConfig));
            TextWriter writer = new StreamWriter(filepath);
            serialzer.Serialize(writer, config);
            writer.Close();
        }

        // Load
        public xmlDataConfig XMLDeserialize(string filePath, xmlDataConfig config)
        {
            serialzer = new XmlSerializer(typeof(xmlDataConfig));
            stream = new FileStream(filePath, FileMode.Open);
            config = (xmlDataConfig)serialzer.Deserialize(stream);
            stream.Close();

            return config;
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
                stream.Dispose();
            }

            this.disposed = true;
        }
    }
}
