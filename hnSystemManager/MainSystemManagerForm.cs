using hnSystemManager.src;
using hnSystemManager.src.util;
using Jerrryfighter.MultipleSocket;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static hnSystemManager.src.xmlDataConfig;

namespace hnSystemManager
{
    public partial class MainSystemManagerForm : Form
    {
        List<CustomPanel> mCustomPanel;

        private readonly string DEVICENAME = "DEVICENAME";
        private readonly char[] SPLIT_CHAR = { '|' ,};

        private readonly string INTRO_VIDEO_PREPARE = "Video Intro Prepare";
        private readonly string INTRO_VIDEO_PLAY = "Intro Video Stop";
        private readonly string INTRO_VIDEO_STOP = "Intro Video Stop";
        private readonly string INTRO_VIDEO_PAUSE = "Intro Video Pause";

        private readonly string MAIN_VIDEO_PREPARE = "Video Main Prepare";
        private readonly string MAIN_VIDEO_PLAY = "Main Video Play";
        private readonly string MAIN_VIDEO_STOP = "Main Video Stop";
        private readonly string MAIN_VIDEO_PAUSE = "Main Video Pause";

        private Thread statusThread;
        private bool isTheadRun = false;

        private int counterMainVideoPrepare;

        enum statusMechine
        {
            IDLE,
            STATUS_INTRO_VIDEO_WAIT,
            STATUS_INTRO_VIDEO_PLAY,
            STATUS_MAIN_VIDEO_WAIT,
            STATUS_MAIN_VIDEO_PLAY,
            STATUS_MAIN_VIDEO_PLAYING,
            END
        }

        statusMechine mStatus;

        public MainSystemManagerForm()
        {
            InitializeComponent();
            mCustomPanel = new List<CustomPanel>();

            if(Program.GetXmlDataConfig().mSystemManager.userUI)
            {
                tableLayoutPanel1.Visible = true;
            }

            updateInformation();

            statusThread = new Thread(statueTh);
            statusThread.IsBackground = true;
            isTheadRun = true;
            statusThread.Start();

            mStatus = statusMechine.IDLE;
        }

        private void statueTh()
        {
            int sleepTime = 1000;
            int counter = 0;

            while (isTheadRun)
            {
                Thread.Sleep(sleepTime);

                switch (mStatus)
                {
                    case statusMechine.IDLE:
                        break;
                    case statusMechine.STATUS_MAIN_VIDEO_WAIT:
                        if(counter < 3)
                        {
                            for(int index =0; index < listView1.Items.Count; index++)
                            {
                                statusMechine stM = (statusMechine) Enum.Parse(typeof(statusMechine), mCustomPanel[index].getStatus());
                                Program.mLogProc.DebugLog("Test : " + stM.ToString());
                                sendSingleMessage("VIDEO_MAIN", index);
                            }

                            counterMainVideoPrepare = 0;
                        }
                        else
                        {
                            Program.mLogProc.DebugLog("Load Error");
                        }
                        counter++;

                        break;
                    case statusMechine.STATUS_MAIN_VIDEO_PLAY:
                        eventProcess("btPlay");
                        mStatus = statusMechine.STATUS_MAIN_VIDEO_PLAYING;
                        counterMainVideoPrepare = 0;
                        counter = 0;
                        break;
                    case statusMechine.STATUS_INTRO_VIDEO_WAIT:
                        {

                        }
                        break;
                    default:
                        break;
                }
            }
        }

        internal void writeDebug(string log)
        {
//            Console.WriteLine(log);
        }

        internal void ListenerDisconnect(Client sender)
        {
            Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    Client client = listView1.Items[i].Tag as Client;

                    if (client.ID == sender.ID)
                    {
                        listView1.Items.RemoveAt(i);
                        delTable(i);
                        break;
                    }
                }

                updateInformation();
            });
        }

        internal void ListenerAccepted(Client client, string cont)
        {
            Invoke((MethodInvoker)delegate
            {
                ListViewItem item = new ListViewItem();
                item.Text = client.EndPoint.ToString();
                item.SubItems.Add(client.ID);
                item.SubItems.Add("XXX");
                item.SubItems.Add("YYY");
                item.SubItems.Add(cont);
                item.Tag = client;
                listView1.Items.Add(item);

                addTable(item);
                updateInformation();
            });
        }

        private void addTable(ListViewItem liItem)
        {
            int customPanelIndex = mCustomPanel.Count;
            int iRowIdx = 0;
            int iColIdx = 0;
            CustomPanel cPanel = new CustomPanel();
            cPanel.Index = customPanelIndex;

            iColIdx = customPanelIndex % 10;
            iRowIdx = customPanelIndex / 10;

            cPanel.setData(liItem);
            cPanel.getPanel().BackColor = Color.Orange;
            cPanel.setVideoType("대기 영상");
            cPanel.getButton().Name = customPanelIndex.ToString();
            cPanel.getButton().Click += new System.EventHandler(this.btSingleEventHandler);
            TableLayoutPanelCellPosition cp = new TableLayoutPanelCellPosition(iColIdx, iRowIdx);
            tableLayoutPanel1.Controls.Add(cPanel.getPanel());
            tableLayoutPanel1.SetCellPosition(cPanel.getPanel(), cp);

            mCustomPanel.Add(cPanel);
        }

        private EventHandler singleEventHandler()
        {
            throw new NotImplementedException();
        }

        private void delTable(int idx)
        {
            int iRowIdx = 0;
            int iColIdx = 0;

            tableLayoutPanel1.Controls.Clear();
            mCustomPanel.Clear();

            for (int index = 0; index < listView1.Items.Count; index++)
            {
                CustomPanel cPanel = new CustomPanel();

                iColIdx = index % 5;
                iRowIdx = index / 5;

                cPanel.setData(listView1.Items[index]);
                if(mStatus == statusMechine.STATUS_MAIN_VIDEO_PLAY)
                {
                    cPanel.getPanel().BackColor = Color.LightGreen;
                }
                else
                {
                    cPanel.getPanel().BackColor = Color.Orange;
                }
                TableLayoutPanelCellPosition cp = new TableLayoutPanelCellPosition(iColIdx, iRowIdx);
                tableLayoutPanel1.Controls.Add(cPanel.getPanel());
                tableLayoutPanel1.SetCellPosition(cPanel.getPanel(), cp);

                mCustomPanel.Add(cPanel);
            }
        }

        private void updateName(int index, string name)
        {
            mCustomPanel[index].setName(name);
        }

        private void updateTable(int index, string message)
        {
            if(message.Contains(MAIN_VIDEO_PREPARE))
            {
                counterMainVideoPrepare++;
                Program.mLogProc.DebugLog("Test : " + counterMainVideoPrepare);

                if (counterMainVideoPrepare == listView1.Items.Count)
                {
                    mStatus = statusMechine.STATUS_MAIN_VIDEO_PLAY;
                    Program.mp3Play();
                }
                mCustomPanel[index].setVideoType("메인 영상");
                mCustomPanel[index].getPanel().BackColor = Color.Orange;
            }
            else if(message.Contains(MAIN_VIDEO_PLAY))
            {
                if(mCustomPanel[index].getPanel().BackColor != Color.LightGreen)
                    mCustomPanel[index].getPanel().BackColor = Color.LightGreen;
            }
            else if (message.Contains(MAIN_VIDEO_STOP))
            {
                Program.getMediaPlayer().Stop();
            }
            else if (message.Contains(MAIN_VIDEO_PAUSE))
            {
                Program.getMediaPlayer().Pause();
            }
            else if (message.Contains(INTRO_VIDEO_PREPARE))
            {
                mCustomPanel[index].setVideoType("대기 영상");
                mCustomPanel[index].getPanel().BackColor = Color.Orange;
                Program.getMediaPlayer().Stop();
            }
            else if (message.Contains(INTRO_VIDEO_PLAY))
            {
            }
            else if (message.Contains(INTRO_VIDEO_STOP))
            {
            }
            else if (message.Contains(INTRO_VIDEO_PAUSE))
            {
            }

            mCustomPanel[index].setStatus(mStatus.ToString());
            mCustomPanel[index].setMessage(message);
        }

        internal void ListenerRecevied(Client sender, byte[] data)
        {
            string message = null;

            Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    Client client = listView1.Items[i].Tag as Client;

                    if (client.ID == sender.ID)
                    {
                        message = Encoding.UTF8.GetString(data, 0, data.Length);

                        string[] command = message.Split(SPLIT_CHAR);
                        if (command[0].Equals(DEVICENAME))
                        {
                            updateName(i, command[1]);
                        }
                        else
                        {
                            updateTable(i, message);
                        }

                        listView1.Items[i].SubItems[2].Text = message;
                        listView1.Items[i].SubItems[3].Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        break;
                    }
                }
            });
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //
                timer1.Tick += new EventHandler(TimerEventProcessor);

                // Sets the timer interval to 10 seconds.
                timer1.Interval = 10000;
                timer1.Start();
            }
            else
                timer1.Stop();
        }

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            Trace.WriteLine("Event raise the TimerEventProcessor");

            Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    Client client = listView1.Items[i].Tag as Client;

                    if (client.sck.Connected)
                        client.SendMessage(BitConverter.GetBytes((int)0));
                    else
                    {
                        this.ListenerDisconnect(client);
                        DisconnectedClientList(client.sck);
                    }
                }
            });
        }

        private void DisconnectedClientList(Socket sck)
        {
            Invoke((MethodInvoker)delegate
            {
                listBox1.Items.Add(sck.Handle.ToString());
                updateInformation();
            });
        }


        private void MainSystemManagerForm_Load(object sender, EventArgs e)
        {
            this.Visible = Program.GetXmlDataConfig().mSystemManager.startVisible;
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Dispose(true);

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                Client client = listView1.Items[i].Tag as Client;

                if (client.sck.Connected)
                    client.Close();
            }

            if (statusThread != null)
                statusThread.Abort();

            isTheadRun = false;
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

        private void sendMessage(String message)
        {
            Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    Client client = listView1.Items[i].Tag as Client;

                    if (client.sck.Connected)
                        client.SendMessage(Encoding.UTF8.GetBytes(message));
                }
            });
        }

        private void sendSingleMessage(String message, int index)
        {
            Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if(i == index)
                    {
                        Client client = listView1.Items[i].Tag as Client;

                        if (client.sck.Connected)
                            client.SendMessage(Encoding.UTF8.GetBytes(message));
                    }
                }
            });
        }


        private void updateInformation()
        {
            lbInformation.Text = "접속 기기 수 : " + listView1.Items.Count;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            String name = button.Name;
            eventProcess(name);
        }

        private void eventProcess(string name)
        {
            if (name.Equals("btIdle"))
            {
                sendMessage("IDLE");
            }
            else if (name.Equals("btVideoIntro"))
            {
                sendMessage("VIDEO_INTRO");
                counterMainVideoPrepare = 0;
            }
            else if (name.Equals("btVideoMain"))
            {
                sendMessage("VIDEO_MAIN");
                mStatus = statusMechine.STATUS_MAIN_VIDEO_WAIT;
            }
            else if (name.Equals("btPlay"))
            {
                sendMessage("VIDEO_PLAY");
            }
            else if (name.Equals("btPause"))
            {
                sendMessage("VIDEO_PAUSE");
                Program.getMediaPlayer().Pause();
            }
            else if (name.Equals("btStop"))
            {
                sendMessage("VIDEO_STOP");
                Program.getMediaPlayer().Stop();
            }
        }

        internal void runMP3()
        {
            Invoke((MethodInvoker)delegate
            {
                Program.mp3Play();
            });
        }

        private void btSingleEventHandler(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int index = int.Parse(button.Name);

            sendSingleMessage("VIDEO_PMAIN", index);
        }
    }
}
