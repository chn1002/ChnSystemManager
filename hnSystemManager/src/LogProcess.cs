using System;
using System.IO;

namespace hnSystemManager.src
{
    class LogProcess
    {
        bool mSaveLogfile = false;
        MainSystemManagerForm mMainsystemForm;

        public LogProcess(Boolean saveLog, MainSystemManagerForm mainSystemForm)
        {
            mSaveLogfile = saveLog;
            mMainsystemForm = mainSystemForm;
        }

        public void DebugLog(string log)
        {
            System.Diagnostics.Debug.WriteLine(log);

            if (mMainsystemForm != null)
            {
                mMainsystemForm.writeDebug(log);
            }
        }

        public void LogWrite(string str)
        {
            string FilePath = Environment.CurrentDirectory + @"\Log\Log_" + DateTime.Today.ToString("yyyyMMdd") + ".log";
            string DirPath = Environment.CurrentDirectory + @"\Log";
            string temp;

            if (mSaveLogfile  != true)
            {
                temp = string.Format("[{0}] {1}", DateTime.Now, str);

                Console.WriteLine(temp);
                return;
            }
            else
            {
                temp = string.Format("[{0}] {1}", DateTime.Now, str);

                DebugLog("config File: " + str);
            }

            DirectoryInfo di = new DirectoryInfo(DirPath);
            FileInfo fi = new FileInfo(FilePath);

            try
            {
                if (!di.Exists) Directory.CreateDirectory(DirPath);
                if (!fi.Exists)
                {
                    using (StreamWriter sw = new StreamWriter(FilePath))
                    {
                        temp = string.Format("[{0}] {1}", DateTime.Now, str);
                        sw.WriteLine(temp);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(FilePath))
                    {
                        temp = string.Format("[{0}] {1}", DateTime.Now, str);
                        sw.WriteLine(temp);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
