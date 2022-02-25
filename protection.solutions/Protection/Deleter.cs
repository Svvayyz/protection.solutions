using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace protection.solutions.Protection
{
    class Deleter
    {
        public static void Delete(string path, string title, string text, string virusname, Color prefixcolor)
        {
            Protector.prefix(prefixcolor);
            Console.Write($" {virusname} detected! \n");
            // deleter
            Program.is_used_by_another_process = false;
            File.Delete(path);
            Protector.prefix(Color.Green);
            Console.Write($" {virusname} deleted! \n");
            // notification
            NotifyIcon notify = new NotifyIcon();
            notify.Icon = new System.Drawing.Icon(Path.GetFullPath("transparent.ico"));
            notify.Text = "protection.solutions";
            notify.Visible = true;
            notify.BalloonTipTitle = title;
            notify.BalloonTipText = text;
            notify.ShowBalloonTip(100);
        }
    }
}
