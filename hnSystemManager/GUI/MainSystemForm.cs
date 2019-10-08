using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChnWatchdog
{
    public partial class MainSystemForm : Form
    {
        delegate void StringArgReturningVoidDelegate(string text);

        public MainSystemForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Program.initSystem();
            loadOSInformation();
        }

        private void loadOSInformation()
        {
            tbOSInformationValue.Text += "@ Directory Path : " + Environment.CurrentDirectory + "\r\n";
            tbOSInformationValue.Text += "@ Process Exit Code : " + Environment.ExitCode + "\r\n";
            tbOSInformationValue.Text += "@ NetBIOS Name : " + Environment.MachineName + "\r\n";
            tbOSInformationValue.Text += "@ OSVersion : " + Environment.OSVersion.ToString() + "\r\n";
            tbOSInformationValue.Text += "@ System Directory : " + Environment.SystemDirectory + "\r\n";
            tbOSInformationValue.Text += "@ System Tick Count : " + Environment.TickCount + "\r\n";
            tbOSInformationValue.Text += "@ Domain Name : " + Environment.UserDomainName + "\r\n";
            tbOSInformationValue.Text += "@ OS Name : " + Environment.UserName + "\r\n";
            tbOSInformationValue.Text += "@ OS Version : " + Environment.Version.ToString() + "\r\n";
            tbOSInformationValue.Text += "@ WorkingSet : " + Environment.WorkingSet + "\r\n";

            OperatingSystem os = Environment.OSVersion;
            Version v = os.Version;

            if (5 == v.Major && v.Minor > 0)
            {
                tbOSInformationValue.Text += "@ OS Version : " + "Windows XP" + "\r\n";
            }

            else if (6 == v.Major && v.Minor == 0)
            {
                tbOSInformationValue.Text += "@ OS Version : " + "Windows VISTA" + "\r\n";
            }

            else if (6 == v.Major && v.Minor == 1)
            {
                tbOSInformationValue.Text += "@ OS Version : " + "Windows 7 " + "\r\n";
            }
            else if (6 == v.Major && v.Minor == 2)
            {
                tbOSInformationValue.Text += "@ OS Version : " + "Windows 10 " + "\r\n";
            }
            else
            {
                tbOSInformationValue.Text += "@ OS" +  v.Major + ": " + v.Minor+ "\r\n";
            }

            tbOSInformationValue.Text += "@ Service Pack : " + os.ServicePack + "\r\n";
            tbOSInformationValue.Text += "@ Build : " + v.Build + "\r\n";
            tbOSInformationValue.Text += "@ Revision : " + v.Revision + "\r\n";
        }

        internal void NetworkWatchDogStatusGUI(bool enable)
        {
            if (enable)
            {
                lbNetworkWatchdogStatusValue.Text = "Enable";
            }
            else
            {
                lbNetworkWatchdogStatusValue.Text = "Disable";
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.checkWatchdog();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;  //notifyicon 더블 클릭시에 해당 어플리케이션을 보여준다. 
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal; // 최소화를 멈춘다 
            this.Activate(); // 폼을 활성화 시킨다
        }

        private void Notify_Resize(object sender, EventArgs e)
        {
            //윈도우 상태가 Minimized일 경우
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false; //창을 보이지 않게 한다.
                this.ShowIcon = false; //작업표시줄에서 제거.

                mSystemNotifyIcon.Visible = true; //트레이 아이콘을 표시한다.
            }
        }

        internal void watchDogStatusGUI(bool enable)
        {
            if (enable)
            {
                lbWatchdogStatusValue.Text = "Enable";
            }
            else
            {
                lbWatchdogStatusValue.Text = "Disable";
            }
        }

        internal void writeMemoryUsage(string memory)
        {
            if (this.lbMemoryUsageValue.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(writeMemoryUsage);
                this.Invoke(d, new object[] { memory });
            }
            else
            {
                this.lbMemoryUsageValue.Text = memory;
            }
        }

        internal void writeCpuUsage(string cpu)
        {
            if (this.lbCPUUsageValue.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(writeCpuUsage);
                this.Invoke(d, new object[] { cpu });
            }
            else
            {
                this.lbCPUUsageValue.Text = cpu;
            }
        }

        internal void writeOSInformation(string osInfor)
        {
            if (this.tbOSInformationValue.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(writeOSInformation);
                this.Invoke(d, new object[] { osInfor });
            }
            else
            {
                this.tbOSInformationValue.Text = osInfor;
            }
        }
        internal void writeUseSerialPort(string serialPort)
        {
            if (this.tbSerialPort.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(writeUseSerialPort);
                this.Invoke(d, new object[] { serialPort });
            }
            else
            {
                this.tbSerialPort.Text = serialPort;
            }
        }

        private void systemClose(object sender, FormClosingEventArgs e)
        {
            Program.systemShutdown();
        }

        internal void writeDebug(string log)
        {
            if (this.mTextboxContent.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(writeDebug);
                this.Invoke(d, new object[] { log });
            }
            else
            {
                this.mTextboxContent.Text = log;
            }
        }

        internal void writeProcessList(string processList)
        {
            if (this.tbProcessList.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(writeProcessList);
                this.Invoke(d, new object[] { processList });
            }
            else
            {
                this.tbProcessList.Text = processList;
            }
        }

        internal void writeWatchdogProcessStatus(string processStatus)
        {
            if (this.lbProcessStatusValue.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(writeWatchdogProcessStatus);
                this.Invoke(d, new object[] { processStatus });
            }
            else
            {
                this.lbProcessStatusValue.Text = processStatus;
            }
        }

        internal void writeUpdateDate(string date)
        {
            if (this.lbProcessUpdate.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(writeUpdateDate);
                this.Invoke(d, new object[] { date });
            }
            else
            {
                this.lbProcessUpdate.Text = date;
            }
        }

        internal void writeWatchdogProcessName(string processName)
        {
            if (this.lbWatchdogProcessName.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(writeWatchdogProcessName);
                this.Invoke(d, new object[] { processName });
            }
            else
            {
                this.lbWatchdogProcessName.Text = processName;
            }
        }
    }
}
