using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Console = Colorful.Console;

namespace protection.solutions.Protection
{
    class windows_notification
    {
        public static void show(string title, string text)
        {
            NotifyIcon notify = new NotifyIcon();
            notify.Icon = new System.Drawing.Icon(Path.GetFullPath("transparent.ico"));
            notify.Text = "protection.solutions";
            notify.Visible = true;
            notify.BalloonTipTitle = title;
            notify.BalloonTipText = text;
            notify.ShowBalloonTip(100);
            notify.MouseDoubleClick += notify_MouseClick;
        }
        public static void notify_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}
