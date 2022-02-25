using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace protection.solutions
{
    class configsystem
    {
        public static void load()
        {
            // creating config file
            if (!File.Exists("config.cfg"))
            {
                File.Create("config.cfg");
                File.WriteAllText("config.cfg", "debug=false \n ransomware_protector=true \n logs=false \n disk=C:\\");
            }
            // loading debug
            if (File.ReadAllLines("config.cfg").Contains("debug=true"))
            {
                Program.debug = true;
            }
            else
            {
                Program.debug = false;
            }
            // loading ransomware_protector
            if (File.ReadAllLines("config.cfg").Contains("ransomware_protector=true"))
            {
                Program.ransomware_protector = true;
            }
            else
            {
                Program.ransomware_protector = false;
            }
            // logs
            if (File.ReadAllLines("config.cfg").Contains("logs=true"))
            {
                Program.logs_enabled = true;
            }
            else
            {
                Program.logs_enabled = false;
            }
        }
    }
}
