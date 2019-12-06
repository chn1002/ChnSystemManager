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
        Label lsControl;
        Label lbMessage;
        Button btControl;
        Panel panel;

        public CustomPanel()
        {
            lbName = new Label();
            lbName.AutoSize = true;
            lbName.Location = new System.Drawing.Point(10, 10);
            lbName.Text = "20";
            lbName.Font = new System.Drawing.Font("굴림", 18, FontStyle.Bold);

            lsVideoType = new Label();
            lsVideoType.AutoSize = true;
            lsVideoType.Location = new System.Drawing.Point(10, 80);
            lsVideoType.Font = new System.Drawing.Font("굴림", 12, FontStyle.Bold);
            lsVideoType.Text = "Control";

            lsControl = new Label();
            lsControl.AutoSize = true;
            lsControl.Location = new System.Drawing.Point(10, 100);
            lsControl.Font = new System.Drawing.Font("굴림", 12, FontStyle.Bold);
            lsControl.Text = "Control";

            lbMessage = new Label();
            lbMessage.AutoSize = true;
            lbMessage.Location = new System.Drawing.Point(10, 120);
            lbMessage.Font = new System.Drawing.Font("굴림", 10, FontStyle.Bold);
            lbMessage.Text = "Message";

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
            panel.Controls.Add(lsControl);
            panel.Controls.Add(btControl);
            panel.Controls.Add(lbMessage);
            isUsing = false;
        }

        public bool IsUsing { get => isUsing; set => isUsing = value; }
        public int Index { get => index; set => index = value; }

        public void setData(ListViewItem item)
        {
            lsControl.Text = item.Text;
            lbMessage.Text = item.SubItems[2].Text;
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

        internal void setControl(string name)
        {
            lsControl.Text = name;
        }

        internal void setMessage(string message)
        {
            lbMessage.Text = message;
        }
    }
}
