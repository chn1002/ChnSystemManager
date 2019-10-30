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
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctMenuStripTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DisplayPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.lbInformation = new System.Windows.Forms.Label();
            this.btPause = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btVideoIntro = new System.Windows.Forms.Button();
            this.btVideoMain = new System.Windows.Forms.Button();
            this.btPlay = new System.Windows.Forms.Button();
            this.btIdle = new System.Windows.Forms.Button();
            this.lbSerivceType = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ctMenuStripTray.SuspendLayout();
            this.DisplayPanel.SuspendLayout();
            this.ControlPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.ctMenuStripTray.Size = new System.Drawing.Size(99, 26);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.systemExit);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(912, 339);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "EndPoint";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Last msg";
            this.columnHeader3.Width = 300;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Last Rec Time";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Socket";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 100;
            // 
            // DisplayPanel
            // 
            this.DisplayPanel.Controls.Add(this.tableLayoutPanel1);
            this.DisplayPanel.Controls.Add(this.listView1);
            this.DisplayPanel.Location = new System.Drawing.Point(0, 105);
            this.DisplayPanel.Name = "DisplayPanel";
            this.DisplayPanel.Size = new System.Drawing.Size(912, 339);
            this.DisplayPanel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, -3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(912, 344);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // ControlPanel
            // 
            this.ControlPanel.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ControlPanel.Controls.Add(this.lbInformation);
            this.ControlPanel.Controls.Add(this.btPause);
            this.ControlPanel.Controls.Add(this.btStop);
            this.ControlPanel.Controls.Add(this.btVideoIntro);
            this.ControlPanel.Controls.Add(this.btVideoMain);
            this.ControlPanel.Controls.Add(this.btPlay);
            this.ControlPanel.Controls.Add(this.btIdle);
            this.ControlPanel.Controls.Add(this.lbSerivceType);
            this.ControlPanel.Controls.Add(this.checkBox1);
            this.ControlPanel.Controls.Add(this.button1);
            this.ControlPanel.Controls.Add(this.textBox1);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlPanel.Location = new System.Drawing.Point(0, 0);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(912, 100);
            this.ControlPanel.TabIndex = 2;
            // 
            // lbInformation
            // 
            this.lbInformation.AutoSize = true;
            this.lbInformation.Location = new System.Drawing.Point(579, 9);
            this.lbInformation.Name = "lbInformation";
            this.lbInformation.Size = new System.Drawing.Size(67, 12);
            this.lbInformation.TabIndex = 10;
            this.lbInformation.Text = "Information";
            // 
            // btPause
            // 
            this.btPause.Location = new System.Drawing.Point(338, 39);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(75, 23);
            this.btPause.TabIndex = 9;
            this.btPause.Text = "Pause";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.button_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(419, 39);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(75, 23);
            this.btStop.TabIndex = 8;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.button_Click);
            // 
            // btVideoIntro
            // 
            this.btVideoIntro.Location = new System.Drawing.Point(95, 39);
            this.btVideoIntro.Name = "btVideoIntro";
            this.btVideoIntro.Size = new System.Drawing.Size(75, 23);
            this.btVideoIntro.TabIndex = 7;
            this.btVideoIntro.Text = "Video Intro";
            this.btVideoIntro.UseVisualStyleBackColor = true;
            this.btVideoIntro.Click += new System.EventHandler(this.button_Click);
            // 
            // btVideoMain
            // 
            this.btVideoMain.Location = new System.Drawing.Point(176, 39);
            this.btVideoMain.Name = "btVideoMain";
            this.btVideoMain.Size = new System.Drawing.Size(75, 23);
            this.btVideoMain.TabIndex = 6;
            this.btVideoMain.Text = "VideoMain";
            this.btVideoMain.UseVisualStyleBackColor = true;
            this.btVideoMain.Click += new System.EventHandler(this.button_Click);
            // 
            // btPlay
            // 
            this.btPlay.Location = new System.Drawing.Point(257, 39);
            this.btPlay.Name = "btPlay";
            this.btPlay.Size = new System.Drawing.Size(75, 23);
            this.btPlay.TabIndex = 5;
            this.btPlay.Text = "Play";
            this.btPlay.UseVisualStyleBackColor = true;
            this.btPlay.Click += new System.EventHandler(this.button_Click);
            // 
            // btIdle
            // 
            this.btIdle.Location = new System.Drawing.Point(14, 39);
            this.btIdle.Name = "btIdle";
            this.btIdle.Size = new System.Drawing.Size(75, 23);
            this.btIdle.TabIndex = 4;
            this.btIdle.Text = "IDLE";
            this.btIdle.UseVisualStyleBackColor = true;
            this.btIdle.Click += new System.EventHandler(this.button_Click);
            // 
            // lbSerivceType
            // 
            this.lbSerivceType.AutoSize = true;
            this.lbSerivceType.Location = new System.Drawing.Point(12, 9);
            this.lbSerivceType.Name = "lbSerivceType";
            this.lbSerivceType.Size = new System.Drawing.Size(47, 12);
            this.lbSerivceType.TabIndex = 3;
            this.lbSerivceType.Text = "Service";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(691, 73);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(192, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Check All Client Connecttions";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(581, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "전송하기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 68);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(563, 21);
            this.textBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 452);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(912, 130);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "삭제 된 클라이언트";
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(3, 17);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(906, 110);
            this.listBox1.TabIndex = 0;
            // 
            // MainSystemManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(912, 582);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.DisplayPanel);
            this.Name = "MainSystemManagerForm";
            this.Text = "SystemManager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.MainSystemManagerForm_Load);
            this.ctMenuStripTray.ResumeLayout(false);
            this.DisplayPanel.ResumeLayout(false);
            this.ControlPanel.ResumeLayout(false);
            this.ControlPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip ctMenuStripTray;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.Panel DisplayPanel;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lbSerivceType;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btVideoIntro;
        private System.Windows.Forms.Button btVideoMain;
        private System.Windows.Forms.Button btPlay;
        private System.Windows.Forms.Button btIdle;
        private System.Windows.Forms.Label lbInformation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

