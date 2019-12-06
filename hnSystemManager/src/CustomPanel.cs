using System;
using System.Drawing;
using System.Windows.Forms;

namespace hnSystemManager.src
{
    public class CustomPanel
    {
        private int index;
        private bool isUsing;
        Label lbName;
        Label lsVideoType;
        Label lbMessage_t1;
        Label lbMessage_t2;
        Label lbMessage_1;
        Label lbMessage_2;
        Button btControl;
        Panel panel;
        string status;

        private readonly char[] SPLIT_DASH_CHAR = { '-', };


        public CustomPanel()
        {
            lbName = new Label();
            lbName.AutoSize = true;
            lbName.Location = new System.Drawing.Point(10, 10);
            lbName.Text = "20";
            lbName.Font = new System.Drawing.Font("굴림", 34, FontStyle.Bold);

            lsVideoType = new Label();
            lsVideoType.AutoSize = true;
            lsVideoType.Location = new System.Drawing.Point(10, 75);
            lsVideoType.Font = new System.Drawing.Font("굴림", 13, FontStyle.Bold);
            lsVideoType.Text = "Control";

            lbMessage_1 = new Label();
            lbMessage_1.Size = new System.Drawing.Size(120, 20);
            lbMessage_1.Location = new System.Drawing.Point(75, 100);
            lbMessage_1.Font = new System.Drawing.Font("굴림", 10, FontStyle.Bold);
            lbMessage_1.Text = "Message1";

            lbMessage_2 = new Label();
            lbMessage_2.Size = new System.Drawing.Size(140, 20);
            lbMessage_2.Location = new System.Drawing.Point(75, 120);
            lbMessage_2.Font = new System.Drawing.Font("굴림", 8, FontStyle.Bold);
            lbMessage_2.Text = "Message2";

            lbMessage_t1 = new Label();
            lbMessage_t1.Size = new System.Drawing.Size(65, 20);
            lbMessage_t1.Location = new System.Drawing.Point(10, 100);
            lbMessage_t1.Font = new System.Drawing.Font("굴림", 9, FontStyle.Bold);
            lbMessage_t1.Text = "재생시간";

            lbMessage_t2 = new Label();
            lbMessage_t2.Size = new System.Drawing.Size(65, 20);
            lbMessage_t2.Location = new System.Drawing.Point(10, 120);
            lbMessage_t2.Font = new System.Drawing.Font("굴림", 8, FontStyle.Bold);
            lbMessage_t2.Text = "영상길이";

            btControl = new Button();
            btControl.Text = "개별시작 버튼";
            btControl.Font = new System.Drawing.Font("굴림", 8, FontStyle.Bold);
            btControl.Location = new System.Drawing.Point(80, 2);
            btControl.Size = new System.Drawing.Size(65, 65);
            btControl.BackColor = Color.Yellow;

            panel = new Panel();
            panel.Size = new System.Drawing.Size(180, 150);
            panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel.Controls.Add(lsVideoType);
            panel.Controls.Add(lbName);
            panel.Controls.Add(btControl);
            panel.Controls.Add(lbMessage_t1);
            panel.Controls.Add(lbMessage_t2);
            panel.Controls.Add(lbMessage_1);
            panel.Controls.Add(lbMessage_2);
            isUsing = false;
            status = "IDLE";
        }

        public bool IsUsing { get => isUsing; set => isUsing = value; }
        public int Index { get => index; set => index = value; }

        public void setData(ListViewItem item)
        {
            lbMessage_1.Text = item.SubItems[2].Text;
            isUsing = true;
        }

        internal Button getButton()
        {
            return btControl;
        }

        internal Panel getPanel()
        {
            return panel;
        }

        internal void setName(string name)
        {
            lbName.Text = name;
        }

        internal void setVideoType(string name)
        {
            lsVideoType.Text = name;
        }

        internal void setMessage(string message)
        {
            string[] timeCommand = message.Split(SPLIT_DASH_CHAR);

            if(timeCommand.Length == 3)
            {
                lbMessage_1.Text = timeCommand[1].Trim(' ');
                lbMessage_2.Text = timeCommand[2].Trim(' ');
            }
            else
            {
                lbMessage_1.Text = message;
            }
        }

        internal void setStatus(string mStatus)
        {
            status = mStatus;
        }

        internal string getStatus( )
        {
            return status;
        }

    }
}
