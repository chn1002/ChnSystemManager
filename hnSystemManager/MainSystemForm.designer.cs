namespace ChnWatchdog
{
    partial class MainSystemForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainSystemForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbWatchdog = new System.Windows.Forms.Label();
            this.lbWatchdogStatusValue = new System.Windows.Forms.Label();
            this.bntWatchdog = new System.Windows.Forms.Button();
            this.mSystemNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mTextboxContent = new System.Windows.Forms.TextBox();
            this.lbWatchdogProcess = new System.Windows.Forms.Label();
            this.lbWatchdogProcessName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbProcessList = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbProcessStatus = new System.Windows.Forms.Label();
            this.lbProcessStatusValue = new System.Windows.Forms.Label();
            this.lbProcessUpdate = new System.Windows.Forms.Label();
            this.lbMemoryUsage = new System.Windows.Forms.Label();
            this.lbCpuUsage = new System.Windows.Forms.Label();
            this.lbMemoryUsageValue = new System.Windows.Forms.Label();
            this.lbCPUUsageValue = new System.Windows.Forms.Label();
            this.lbSerial = new System.Windows.Forms.Label();
            this.tbSerialPort = new System.Windows.Forms.TextBox();
            this.lbOSInformation = new System.Windows.Forms.Label();
            this.tbOSInformationValue = new System.Windows.Forms.TextBox();
            this.tbNetworkWatchdog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbNetworkWatchdogStatusValue = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1188, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 22);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // lbWatchdog
            // 
            this.lbWatchdog.AutoSize = true;
            this.lbWatchdog.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbWatchdog.Location = new System.Drawing.Point(8, 29);
            this.lbWatchdog.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbWatchdog.Name = "lbWatchdog";
            this.lbWatchdog.Size = new System.Drawing.Size(114, 12);
            this.lbWatchdog.TabIndex = 1;
            this.lbWatchdog.Text = "Watchdog Status";
            // 
            // lbWatchdogStatusValue
            // 
            this.lbWatchdogStatusValue.AutoSize = true;
            this.lbWatchdogStatusValue.Location = new System.Drawing.Point(165, 29);
            this.lbWatchdogStatusValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbWatchdogStatusValue.Name = "lbWatchdogStatusValue";
            this.lbWatchdogStatusValue.Size = new System.Drawing.Size(99, 12);
            this.lbWatchdogStatusValue.TabIndex = 2;
            this.lbWatchdogStatusValue.Text = "watchdog Status";
            // 
            // bntWatchdog
            // 
            this.bntWatchdog.Location = new System.Drawing.Point(281, 18);
            this.bntWatchdog.Margin = new System.Windows.Forms.Padding(2);
            this.bntWatchdog.Name = "bntWatchdog";
            this.bntWatchdog.Size = new System.Drawing.Size(71, 23);
            this.bntWatchdog.TabIndex = 3;
            this.bntWatchdog.Text = "WatchDog";
            this.bntWatchdog.UseVisualStyleBackColor = true;
            this.bntWatchdog.Click += new System.EventHandler(this.button1_Click);
            // 
            // mSystemNotifyIcon
            // 
            this.mSystemNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("mSystemNotifyIcon.Icon")));
            this.mSystemNotifyIcon.Text = "ChnSystemManager";
            this.mSystemNotifyIcon.Visible = true;
            this.mSystemNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // mTextboxContent
            // 
            this.mTextboxContent.Location = new System.Drawing.Point(7, 374);
            this.mTextboxContent.Margin = new System.Windows.Forms.Padding(2);
            this.mTextboxContent.Multiline = true;
            this.mTextboxContent.Name = "mTextboxContent";
            this.mTextboxContent.Size = new System.Drawing.Size(345, 98);
            this.mTextboxContent.TabIndex = 4;
            // 
            // lbWatchdogProcess
            // 
            this.lbWatchdogProcess.AutoSize = true;
            this.lbWatchdogProcess.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbWatchdogProcess.Location = new System.Drawing.Point(8, 54);
            this.lbWatchdogProcess.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbWatchdogProcess.Name = "lbWatchdogProcess";
            this.lbWatchdogProcess.Size = new System.Drawing.Size(127, 12);
            this.lbWatchdogProcess.TabIndex = 5;
            this.lbWatchdogProcess.Text = "Watchdog Process";
            // 
            // lbWatchdogProcessName
            // 
            this.lbWatchdogProcessName.AutoSize = true;
            this.lbWatchdogProcessName.Location = new System.Drawing.Point(165, 54);
            this.lbWatchdogProcessName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbWatchdogProcessName.Name = "lbWatchdogProcessName";
            this.lbWatchdogProcessName.Size = new System.Drawing.Size(110, 12);
            this.lbWatchdogProcessName.TabIndex = 6;
            this.lbWatchdogProcessName.Text = "watchdog process";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(8, 351);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "Log Box";
            // 
            // tbProcessList
            // 
            this.tbProcessList.Location = new System.Drawing.Point(10, 138);
            this.tbProcessList.Margin = new System.Windows.Forms.Padding(2);
            this.tbProcessList.Multiline = true;
            this.tbProcessList.Name = "tbProcessList";
            this.tbProcessList.Size = new System.Drawing.Size(342, 200);
            this.tbProcessList.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(8, 104);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Process List";
            // 
            // lbProcessStatus
            // 
            this.lbProcessStatus.AutoSize = true;
            this.lbProcessStatus.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbProcessStatus.Location = new System.Drawing.Point(8, 79);
            this.lbProcessStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbProcessStatus.Name = "lbProcessStatus";
            this.lbProcessStatus.Size = new System.Drawing.Size(105, 12);
            this.lbProcessStatus.TabIndex = 10;
            this.lbProcessStatus.Text = "Process Status";
            // 
            // lbProcessStatusValue
            // 
            this.lbProcessStatusValue.AutoSize = true;
            this.lbProcessStatusValue.Location = new System.Drawing.Point(165, 79);
            this.lbProcessStatusValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbProcessStatusValue.Name = "lbProcessStatusValue";
            this.lbProcessStatusValue.Size = new System.Drawing.Size(40, 12);
            this.lbProcessStatusValue.TabIndex = 11;
            this.lbProcessStatusValue.Text = "Status";
            // 
            // lbProcessUpdate
            // 
            this.lbProcessUpdate.AutoSize = true;
            this.lbProcessUpdate.Location = new System.Drawing.Point(165, 104);
            this.lbProcessUpdate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbProcessUpdate.Name = "lbProcessUpdate";
            this.lbProcessUpdate.Size = new System.Drawing.Size(73, 12);
            this.lbProcessUpdate.TabIndex = 12;
            this.lbProcessUpdate.Text = "Update Date";
            // 
            // lbMemoryUsage
            // 
            this.lbMemoryUsage.AutoSize = true;
            this.lbMemoryUsage.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbMemoryUsage.Location = new System.Drawing.Point(403, 52);
            this.lbMemoryUsage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMemoryUsage.Name = "lbMemoryUsage";
            this.lbMemoryUsage.Size = new System.Drawing.Size(123, 12);
            this.lbMemoryUsage.TabIndex = 13;
            this.lbMemoryUsage.Text = "Available Memory";
            // 
            // lbCpuUsage
            // 
            this.lbCpuUsage.AutoSize = true;
            this.lbCpuUsage.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbCpuUsage.Location = new System.Drawing.Point(403, 29);
            this.lbCpuUsage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCpuUsage.Name = "lbCpuUsage";
            this.lbCpuUsage.Size = new System.Drawing.Size(79, 12);
            this.lbCpuUsage.TabIndex = 14;
            this.lbCpuUsage.Text = "CPU Usage";
            // 
            // lbMemoryUsageValue
            // 
            this.lbMemoryUsageValue.AutoSize = true;
            this.lbMemoryUsageValue.Location = new System.Drawing.Point(560, 52);
            this.lbMemoryUsageValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMemoryUsageValue.Name = "lbMemoryUsageValue";
            this.lbMemoryUsageValue.Size = new System.Drawing.Size(91, 12);
            this.lbMemoryUsageValue.TabIndex = 15;
            this.lbMemoryUsageValue.Text = "memory usage";
            // 
            // lbCPUUsageValue
            // 
            this.lbCPUUsageValue.AutoSize = true;
            this.lbCPUUsageValue.Location = new System.Drawing.Point(560, 29);
            this.lbCPUUsageValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCPUUsageValue.Name = "lbCPUUsageValue";
            this.lbCPUUsageValue.Size = new System.Drawing.Size(65, 12);
            this.lbCPUUsageValue.TabIndex = 16;
            this.lbCPUUsageValue.Text = "cpu usage";
            // 
            // lbSerial
            // 
            this.lbSerial.AutoSize = true;
            this.lbSerial.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbSerial.Location = new System.Drawing.Point(403, 79);
            this.lbSerial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSerial.Name = "lbSerial";
            this.lbSerial.Size = new System.Drawing.Size(74, 12);
            this.lbSerial.TabIndex = 17;
            this.lbSerial.Text = "Serial Port";
            // 
            // tbSerialPort
            // 
            this.tbSerialPort.Location = new System.Drawing.Point(405, 104);
            this.tbSerialPort.Margin = new System.Windows.Forms.Padding(2);
            this.tbSerialPort.Multiline = true;
            this.tbSerialPort.Name = "tbSerialPort";
            this.tbSerialPort.Size = new System.Drawing.Size(305, 98);
            this.tbSerialPort.TabIndex = 19;
            // 
            // lbOSInformation
            // 
            this.lbOSInformation.AutoSize = true;
            this.lbOSInformation.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbOSInformation.Location = new System.Drawing.Point(403, 224);
            this.lbOSInformation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbOSInformation.Name = "lbOSInformation";
            this.lbOSInformation.Size = new System.Drawing.Size(102, 12);
            this.lbOSInformation.TabIndex = 20;
            this.lbOSInformation.Text = "OS Information";
            // 
            // tbOSInformationValue
            // 
            this.tbOSInformationValue.Location = new System.Drawing.Point(405, 251);
            this.tbOSInformationValue.Margin = new System.Windows.Forms.Padding(2);
            this.tbOSInformationValue.Multiline = true;
            this.tbOSInformationValue.Name = "tbOSInformationValue";
            this.tbOSInformationValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOSInformationValue.Size = new System.Drawing.Size(305, 221);
            this.tbOSInformationValue.TabIndex = 21;
            // 
            // tbNetworkWatchdog
            // 
            this.tbNetworkWatchdog.Location = new System.Drawing.Point(768, 54);
            this.tbNetworkWatchdog.Margin = new System.Windows.Forms.Padding(2);
            this.tbNetworkWatchdog.Multiline = true;
            this.tbNetworkWatchdog.Name = "tbNetworkWatchdog";
            this.tbNetworkWatchdog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNetworkWatchdog.Size = new System.Drawing.Size(398, 418);
            this.tbNetworkWatchdog.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(766, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "Network Watchdog";
            // 
            // lbNetworkWatchdogStatusValue
            // 
            this.lbNetworkWatchdogStatusValue.AutoSize = true;
            this.lbNetworkWatchdogStatusValue.Location = new System.Drawing.Point(896, 27);
            this.lbNetworkWatchdogStatusValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNetworkWatchdogStatusValue.Name = "lbNetworkWatchdogStatusValue";
            this.lbNetworkWatchdogStatusValue.Size = new System.Drawing.Size(90, 12);
            this.lbNetworkWatchdogStatusValue.TabIndex = 24;
            this.lbNetworkWatchdogStatusValue.Text = "Network Status";
            // 
            // MainSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1188, 485);
            this.Controls.Add(this.lbNetworkWatchdogStatusValue);
            this.Controls.Add(this.tbNetworkWatchdog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbOSInformationValue);
            this.Controls.Add(this.lbOSInformation);
            this.Controls.Add(this.tbSerialPort);
            this.Controls.Add(this.lbSerial);
            this.Controls.Add(this.lbCPUUsageValue);
            this.Controls.Add(this.lbMemoryUsageValue);
            this.Controls.Add(this.lbCpuUsage);
            this.Controls.Add(this.lbMemoryUsage);
            this.Controls.Add(this.lbProcessUpdate);
            this.Controls.Add(this.lbProcessStatusValue);
            this.Controls.Add(this.lbProcessStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbProcessList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbWatchdogProcessName);
            this.Controls.Add(this.lbWatchdogProcess);
            this.Controls.Add(this.mTextboxContent);
            this.Controls.Add(this.bntWatchdog);
            this.Controls.Add(this.lbWatchdogStatusValue);
            this.Controls.Add(this.lbWatchdog);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainSystemForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "ChnSystemManager";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.systemClose);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Notify_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label lbWatchdog;
        private System.Windows.Forms.Label lbWatchdogStatusValue;
        private System.Windows.Forms.Button bntWatchdog;
        private System.Windows.Forms.NotifyIcon mSystemNotifyIcon;
        private System.Windows.Forms.TextBox mTextboxContent;
        private System.Windows.Forms.Label lbWatchdogProcess;
        private System.Windows.Forms.Label lbWatchdogProcessName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbProcessList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbProcessStatus;
        private System.Windows.Forms.Label lbProcessStatusValue;
        private System.Windows.Forms.Label lbProcessUpdate;
        private System.Windows.Forms.Label lbMemoryUsage;
        private System.Windows.Forms.Label lbCpuUsage;
        private System.Windows.Forms.Label lbMemoryUsageValue;
        private System.Windows.Forms.Label lbCPUUsageValue;
        private System.Windows.Forms.Label lbSerial;
        private System.Windows.Forms.TextBox tbSerialPort;
        private System.Windows.Forms.Label lbOSInformation;
        private System.Windows.Forms.TextBox tbOSInformationValue;
        private System.Windows.Forms.TextBox tbNetworkWatchdog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbNetworkWatchdogStatusValue;
    }
}

