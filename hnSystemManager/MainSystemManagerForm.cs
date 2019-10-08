using hnSystemManager.src.util;
using System;
using System.Windows.Forms;
using static hnSystemManager.src.xmlDataConfig;

namespace hnSystemManager
{
    public partial class MainSystemManagerForm : Form
    {
        private readonly int WIDTH_GAP = 120;
        private readonly int HEIGHT_GAP = 30;

        class networkGUI
        {
            internal Label lbIndex;
            internal Label lbNetwork;
            internal Label lbNetworkPort;
            internal Label lbNetworkStatus;
            internal Label lbNetworkPortStatus;
            internal Label lbContentsStatus;
            internal TextBox tbCommandTextBox;
            internal Label lbCommandResult;
            internal Button btCheckButton;
        }

        networkGUI[] netGUIEntry;

        public MainSystemManagerForm()
        {
            InitializeComponent();
            InitializeCustomComponent();
        }

        private void InitializeCustomComponent()
        {
            int index = 0;
            int counter = 0;
            netGUIEntry = new networkGUI[Program.GetXmlDataConfig().NetworkSystem.Length];

            foreach (NetworkSystemEntry nsE in Program.GetXmlDataConfig().NetworkSystem)
            {
                if (nsE != null)
                {
                    netGUIEntry[index] = new networkGUI();
                    netGUIEntry[index].lbIndex = new Label();
                    netGUIEntry[index].lbIndex.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    netGUIEntry[index].lbIndex.Location = new System.Drawing.Point(12, 50 + (index * HEIGHT_GAP));
                    netGUIEntry[index].lbIndex.Name = "lbIndex" + index;
                    netGUIEntry[index].lbIndex.Size = new System.Drawing.Size(30, 20);
                    netGUIEntry[index].lbIndex.TabIndex = index;
                    netGUIEntry[index].lbIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    netGUIEntry[index].lbIndex.Text = (index + 1).ToString();

                    netGUIEntry[index].lbNetwork = new Label();
                    CreateCustomLabel(netGUIEntry[index].lbNetwork, 
                        index, 
                        80 + (counter++ * WIDTH_GAP), 
                        50 + (index * HEIGHT_GAP), 
                        "lbNetwork" + index, 
                        nsE.NetworkAddress);

                    netGUIEntry[index].lbNetworkPort = new Label();
                    CreateCustomLabel(netGUIEntry[index].lbNetworkPort,
                        index,
                        80 + (counter++ * WIDTH_GAP),
                        50 + (index * HEIGHT_GAP),
                        "lbNetworkPort" + index,
                        nsE.port.ToString());

                    netGUIEntry[index].lbNetworkStatus = new Label();
                    CreateCustomLabel(netGUIEntry[index].lbNetworkStatus,
                        index,
                        80 + (counter++ * WIDTH_GAP),
                        50 + (index * HEIGHT_GAP),
                        "lbNetworkStatus" + index,
                        "알수없음");

                    netGUIEntry[index].lbNetworkPortStatus = new Label();
                    CreateCustomLabel(netGUIEntry[index].lbNetworkPortStatus,
                        index,
                        80 + (counter++ * WIDTH_GAP),
                        50 + (index * HEIGHT_GAP),
                        "lbNetworkPortStatus" + index,
                        "알수없음");

                    netGUIEntry[index].lbContentsStatus = new Label();
                    CreateCustomLabel(netGUIEntry[index].lbContentsStatus,
                        index,
                        80 + (counter++ * WIDTH_GAP),
                        50 + (index * HEIGHT_GAP),
                        "lbContentsStatus" + index,
                        "알수없음");
                    
                    netGUIEntry[index].tbCommandTextBox = new TextBox();
                    CreateCustomTextbox(netGUIEntry[index].tbCommandTextBox,
                        index,
                        80 + (counter++ * WIDTH_GAP),
                        50 + (index * HEIGHT_GAP),
                        "tbCommand" + index);

                    netGUIEntry[index].lbCommandResult = new Label();
                    CreateCustomLabel(netGUIEntry[index].lbCommandResult,
                        index,
                        80 + (counter++ * WIDTH_GAP),
                        50 + (index * HEIGHT_GAP),
                        "lbCommandResult" + index,
                        "알수없음");

                    netGUIEntry[index].btCheckButton = new Button();
                    CreateCustomButton(netGUIEntry[index].btCheckButton,
                        index,
                        80 + (counter++ * WIDTH_GAP),
                        50 + (index * HEIGHT_GAP),
                        "btCheck" + index,
                        "명령실행");

                    Controls.Add(netGUIEntry[index].lbIndex);
                    Controls.Add(netGUIEntry[index].lbNetwork);
                    Controls.Add(netGUIEntry[index].lbNetworkPort);
                    Controls.Add(netGUIEntry[index].lbNetworkStatus);
                    Controls.Add(netGUIEntry[index].lbNetworkPortStatus);
                    Controls.Add(netGUIEntry[index].lbContentsStatus);
                    Controls.Add(netGUIEntry[index].lbCommandResult);
                    Controls.Add(netGUIEntry[index].tbCommandTextBox);
                    Controls.Add(netGUIEntry[index].btCheckButton);

                    index++;
                    counter = 0;
                }
            }

            lbStatusValue.Text = "초기값";
            lbConnectionClient.Text = "없음";
        }

        internal void setRemoteControlerClientInformation(string information)
        {
            this.Invoke(new Action(delegate ()
            {
                lbConnectionClient.Text = information;
            }));
        }

        private void CreateCustomLabel(Label lbCustom, int index, int xPoint, int yPoint, string name, string text)
        {
            lbCustom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lbCustom.Location = new System.Drawing.Point(xPoint, yPoint);
            lbCustom.Name = name;
            lbCustom.Size = new System.Drawing.Size(75, 20);
            lbCustom.TabIndex = index;
            lbCustom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lbCustom.Text = text;
        }

        private void CreateCustomTextbox(TextBox tbCustom, int index, int xPoint, int yPoint, string name)
        {
            tbCustom.Location = new System.Drawing.Point(xPoint, yPoint);
            tbCustom.Name = name;
            tbCustom.Size = new System.Drawing.Size(100, 21);
            tbCustom.TabIndex = index;
        }

        private void CreateCustomButton(Button btCustom, int index, int xPoint, int yPoint, string name, string text)
        {
            btCustom.Location = new System.Drawing.Point(xPoint, yPoint);
            btCustom.Name = name;
            btCustom.Size = new System.Drawing.Size(75, 23);
            btCustom.TabIndex = index;
            btCustom.Text = text;
            btCustom.UseVisualStyleBackColor = true;
            btCustom.Click += new System.EventHandler(btCheck_Click);
        }

        private void btCheck_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int index = clickedButton.TabIndex;
            lbStatusValue.Text = "테스트 중";

            bool resultCommand = false;

            if(Program.getSystemConnectionClient(index))
            {
                resultCommand = Program.sendSystemCommand(index, netGUIEntry[index].tbCommandTextBox.Text);
            }

            if(resultCommand)
            {
                netGUIEntry[index].lbCommandResult.Text = "전송 성공";
                netGUIEntry[index].lbCommandResult.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                netGUIEntry[index].lbCommandResult.Text = "전송 실패";
                netGUIEntry[index].lbCommandResult.ForeColor = System.Drawing.Color.Red;
            }

            lbStatusValue.Text = "테스트 완료";
        }

        internal void writeDebug(string log)
        {
            Console.WriteLine(log);
        }

        private void btICMPTest_Click(object sender, EventArgs e)
        {
            bool icmpTest = false;
            lbStatusValue.Text = "테스트 중";

            for (int index = 0; index < netGUIEntry.Length; index++)
            {
                icmpTest = Program.systemClientICMPTest(index);

                if (icmpTest)
                {
                    netGUIEntry[index].lbNetworkStatus.Text = "접속 가능";
                    netGUIEntry[index].lbNetworkStatus.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    netGUIEntry[index].lbNetworkStatus.Text = "접속 불가";
                    netGUIEntry[index].lbNetworkStatus.ForeColor = System.Drawing.Color.Red;
                }
            }

            lbStatusValue.Text = "테스트 완료";
        }

        private void btPortTest_Click(object sender, EventArgs e)
        {
            bool portResult = false;
            lbStatusValue.Text = "테스트 중";

            for (int index = 0; index < netGUIEntry.Length; index++)
            {
                portResult = Program.systemClientPortScan(index);


                if (portResult)
                {
                    netGUIEntry[index].lbNetworkPortStatus.Text = "접속 가능";
                    netGUIEntry[index].lbNetworkPortStatus.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    netGUIEntry[index].lbNetworkPortStatus.Text = "접속 불가";
                    netGUIEntry[index].lbNetworkPortStatus.ForeColor = System.Drawing.Color.Red;
                }
            }

            lbStatusValue.Text = "테스트 완료";
        }

        private void btContents_Click(object sender, EventArgs e)
        {
            bool clientResult = false;
            lbStatusValue.Text = "테스트 중";

            for (int index = 0; index < netGUIEntry.Length; index++)
            {
                clientResult = Program.systemClientScan(index);


                if (clientResult)
                {
                    netGUIEntry[index].lbContentsStatus.Text = "접속 가능";
                    netGUIEntry[index].lbContentsStatus.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    netGUIEntry[index].lbContentsStatus.Text = "접속 불가";
                    netGUIEntry[index].lbContentsStatus.ForeColor = System.Drawing.Color.Red;
                }
            }

            lbStatusValue.Text = "테스트 완료";
        }

        private void btAllCommand_Click(object sender, EventArgs e)
        {
            lbStatusValue.Text = "테스트 중";
            string command = tbCommand.Text;
            bool resultCommand = false;

            for (int index = 0; index < netGUIEntry.Length; index++)
            {
                if (Program.getSystemConnectionClient(index))
                {
                    resultCommand = Program.sendSystemCommand(index, command);
                }
                else
                {
                    resultCommand = false;
                }

                if (resultCommand)
                {
                    netGUIEntry[index].lbCommandResult.Text = "전송 성공";
                    netGUIEntry[index].lbCommandResult.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    netGUIEntry[index].lbCommandResult.Text = "전송 실패";
                    netGUIEntry[index].lbCommandResult.ForeColor = System.Drawing.Color.Red;
                }

                netGUIEntry[index].tbCommandTextBox.Text = command;
            }

            lbStatusValue.Text = "테스트 완료";
        }

        public void InitializeNetwork()
        {
            bool icmpTest = false;
            bool clientResult = false;
            bool portResult = false;

            for (int index = 0; index < netGUIEntry.Length; index++)
            {
                icmpTest = Program.systemClientICMPTest(index);
                portResult = Program.systemClientPortScan(index);
                clientResult = Program.systemClientScan(index);

                if (icmpTest)
                {
                    netGUIEntry[index].lbNetworkStatus.Text = "접속 가능";
                    netGUIEntry[index].lbNetworkStatus.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    netGUIEntry[index].lbNetworkStatus.Text = "접속 불가";
                    netGUIEntry[index].lbNetworkStatus.ForeColor = System.Drawing.Color.Red;
                }

                if (portResult)
                {
                    netGUIEntry[index].lbNetworkPortStatus.Text = "접속 가능";
                    netGUIEntry[index].lbNetworkPortStatus.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    netGUIEntry[index].lbNetworkPortStatus.Text = "접속 불가";
                    netGUIEntry[index].lbNetworkPortStatus.ForeColor = System.Drawing.Color.Red;
                }

                if (clientResult)
                {
                    netGUIEntry[index].lbContentsStatus.Text = "접속 가능";
                    netGUIEntry[index].lbContentsStatus.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    netGUIEntry[index].lbContentsStatus.Text = "접속 불가";
                    netGUIEntry[index].lbContentsStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void MainSystemManagerForm_Load(object sender, EventArgs e)
        {
            this.Visible = Program.GetXmlDataConfig().mSystemManager.startVisible;
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Dispose(true);
            Program.systemShutdown();
        }

        internal void from_exit()
        {
            this.Invoke(new Action(delegate ()
            {
                notifyIcon1.Visible = false;
            }));
        }

        private void notifyIconDClick(object sender, MouseEventArgs e)
        {
            if(this.Visible)
            {
                this.Visible = false;
            }
            else
            {
                this.Visible = true;
            }

        }

        private void systemExit(object sender, EventArgs e)
        {
            Program.systemShutdown();
        }
    }
}
