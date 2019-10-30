using hnSystemManager.src;
using hnSystemManager.src.util;
using Jerrryfighter.MultipleSocket;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using static hnSystemManager.src.xmlDataConfig;

namespace hnSystemManager
{
    public partial class MainSystemManagerForm : Form
    {
        List<CustomPanel> mCustomPanel;

        public MainSystemManagerForm()
        {
            InitializeComponent();
            mCustomPanel = new List<CustomPanel>();

            lbSerivceType.Text = "Service Type: Server Mode";
            updateInformation();
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

            iColIdx = customPanelIndex % 5;
            iRowIdx = customPanelIndex / 5;

            cPanel.setData(liItem);
            TableLayoutPanelCellPosition cp = new TableLayoutPanelCellPosition(iColIdx, iRowIdx);
            tableLayoutPanel1.Controls.Add(cPanel.getPanel());
            tableLayoutPanel1.SetCellPosition(cPanel.getPanel(), cp);

            mCustomPanel.Add(cPanel);
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
                TableLayoutPanelCellPosition cp = new TableLayoutPanelCellPosition(iColIdx, iRowIdx);
                tableLayoutPanel1.Controls.Add(cPanel.getPanel());
                tableLayoutPanel1.SetCellPosition(cPanel.getPanel(), cp);

                mCustomPanel.Add(cPanel);
            }
        }

        private void updateTable(int index, string message)
        {
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
                        listView1.Items[i].SubItems[2].Text = message;
                        listView1.Items[i].SubItems[3].Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        updateTable(i, message);
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
            Program.mLogProc.DebugLog("Test : " + message);

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

        private void updateInformation()
        {
            lbInformation.Text = "Client Number: " + listView1.Items.Count;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            String name = button.Name;

            if (name.Equals("btIdle"))
            {
                sendMessage("IDLE");
            } else if (name.Equals("btVideoIntro"))
            {
                sendMessage("VIDEO_INTRO");
            } else if (name.Equals("btVideoMain"))
            {
                sendMessage("VIDEO_MAIN");
            } else if (name.Equals("btPlay"))
            {
                sendMessage("VIDEO_PLAY");
            } else if (name.Equals("btPause"))
            {
                sendMessage("VIDEO_PAUSE");
            } else if (name.Equals("btStop"))
            {
                sendMessage("VIDEO_STOP");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sendMessage(textBox1.Text);
        }

    }
}
