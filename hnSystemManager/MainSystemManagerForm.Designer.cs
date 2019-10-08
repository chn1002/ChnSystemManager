namespace hnSystemManager
{
    partial class MainSystemManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainSystemManagerForm));
            this.btICMPTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btPortTest = new System.Windows.Forms.Button();
            this.btContents = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbStatusValue = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCommand = new System.Windows.Forms.TextBox();
            this.btAllCommand = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbConnectionClient = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctMenuStripTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctMenuStripTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // btICMPTest
            // 
            this.btICMPTest.Location = new System.Drawing.Point(1084, 67);
            this.btICMPTest.Name = "btICMPTest";
            this.btICMPTest.Size = new System.Drawing.Size(103, 38);
            this.btICMPTest.TabIndex = 7;
            this.btICMPTest.Text = "네트워크 테스트";
            this.btICMPTest.UseVisualStyleBackColor = true;
            this.btICMPTest.Click += new System.EventHandler(this.btICMPTest_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(80, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "IP 주소";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(200, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "포트";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(300, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "네트워크 상태";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(680, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "명령";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "번호";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(420, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "포트 상태";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(540, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "컨탠츠 상태";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btPortTest
            // 
            this.btPortTest.Location = new System.Drawing.Point(1084, 111);
            this.btPortTest.Name = "btPortTest";
            this.btPortTest.Size = new System.Drawing.Size(103, 38);
            this.btPortTest.TabIndex = 15;
            this.btPortTest.Text = "포트 테스트";
            this.btPortTest.UseVisualStyleBackColor = true;
            this.btPortTest.Click += new System.EventHandler(this.btPortTest_Click);
            // 
            // btContents
            // 
            this.btContents.Location = new System.Drawing.Point(1084, 155);
            this.btContents.Name = "btContents";
            this.btContents.Size = new System.Drawing.Size(103, 38);
            this.btContents.TabIndex = 16;
            this.btContents.Text = "캔탠츠 테스트";
            this.btContents.UseVisualStyleBackColor = true;
            this.btContents.Click += new System.EventHandler(this.btContents_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbStatus.Location = new System.Drawing.Point(1082, 17);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(31, 12);
            this.lbStatus.TabIndex = 17;
            this.lbStatus.Text = "상태";
            // 
            // lbStatusValue
            // 
            this.lbStatusValue.AutoSize = true;
            this.lbStatusValue.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbStatusValue.Location = new System.Drawing.Point(1082, 42);
            this.lbStatusValue.Name = "lbStatusValue";
            this.lbStatusValue.Size = new System.Drawing.Size(66, 12);
            this.lbStatusValue.TabIndex = 18;
            this.lbStatusValue.Text = "Checking";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(800, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "결과";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbCommand
            // 
            this.tbCommand.Location = new System.Drawing.Point(1084, 245);
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new System.Drawing.Size(100, 21);
            this.tbCommand.TabIndex = 20;
            // 
            // btAllCommand
            // 
            this.btAllCommand.Location = new System.Drawing.Point(1084, 272);
            this.btAllCommand.Name = "btAllCommand";
            this.btAllCommand.Size = new System.Drawing.Size(103, 38);
            this.btAllCommand.TabIndex = 21;
            this.btAllCommand.Text = "명령 전송";
            this.btAllCommand.UseVisualStyleBackColor = true;
            this.btAllCommand.Click += new System.EventHandler(this.btAllCommand_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(1082, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 12);
            this.label9.TabIndex = 22;
            this.label9.Text = "명령";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(1082, 331);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 12);
            this.label10.TabIndex = 23;
            this.label10.Text = "접속 Client";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbConnectionClient
            // 
            this.lbConnectionClient.AutoSize = true;
            this.lbConnectionClient.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbConnectionClient.Location = new System.Drawing.Point(1082, 358);
            this.lbConnectionClient.Name = "lbConnectionClient";
            this.lbConnectionClient.Size = new System.Drawing.Size(41, 12);
            this.lbConnectionClient.TabIndex = 24;
            this.lbConnectionClient.Text = "client";
            this.lbConnectionClient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.ctMenuStripTray;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SystemManager";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconDClick);
            // 
            // ctMenuStripTray
            // 
            this.ctMenuStripTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.종료ToolStripMenuItem});
            this.ctMenuStripTray.Name = "ctMenuStripTray";
            this.ctMenuStripTray.Size = new System.Drawing.Size(181, 48);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.systemExit);
            // 
            // MainSystemManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1199, 624);
            this.Controls.Add(this.lbConnectionClient);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btAllCommand);
            this.Controls.Add(this.tbCommand);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbStatusValue);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.btContents);
            this.Controls.Add(this.btPortTest);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btICMPTest);
            this.Name = "MainSystemManagerForm";
            this.Text = "SystemManager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.MainSystemManagerForm_Load);
            this.ctMenuStripTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btICMPTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btPortTest;
        private System.Windows.Forms.Button btContents;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lbStatusValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbCommand;
        private System.Windows.Forms.Button btAllCommand;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbConnectionClient;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip ctMenuStripTray;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
    }
}

