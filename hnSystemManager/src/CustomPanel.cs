using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hnSystemManager.src
{
    public class CustomPanel
    {
        Label lsControl;
        Label lbMessage;
        Panel panel;
        bool isUsing;

        public CustomPanel()
        {
            lsControl = new Label();
            lsControl.AutoSize = true;
            lsControl.Location = new System.Drawing.Point(3, 10);

            lbMessage = new Label();
            lbMessage.AutoSize = true;
            lbMessage.Location = new System.Drawing.Point(3, 25);

            panel = new Panel();
            panel.AutoSizeMode = AutoSizeMode.GrowOnly;
            panel.Controls.Add(lsControl);
            panel.Controls.Add(lbMessage);
            isUsing = false;
        }

        public bool IsUsing { get => isUsing; set => isUsing = value; }

        public void setData(ListViewItem item)
        {
            lsControl.Text = item.Text;
            lbMessage.Text = item.SubItems[2].Text;
            isUsing = true;
        }

        internal Panel getPanel()
        {
            return panel;
        }

        internal void setMessage(string message)
        {
            lbMessage.Text = message;
        }
    }
}
