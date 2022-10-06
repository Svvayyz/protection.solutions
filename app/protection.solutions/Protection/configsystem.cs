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
                File.WriteAllText("config.cfg", "debug=false \n ransomware_protector=true \n logs=false");
            }

            if (!File.Exists("additional.cfg"))
            {
                File.Create("additional.cfg");
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

            string[] lines = File.ReadAllLines("additional.cfg");
            for(int i=1; i<lines.Count(); i++)
            {
                string[] args = lines[i].Split('-');

                if(args.Count() >= 3 && args.Count() <= 3)
                {
                    Protector.AdditionalDetections[args[0]] = args[1] + $" ({args[2]})";
                    logsystem.log($"LOADED | {args[1]} (STATUS: COMPLETED | THREAT LEVEL: {args[2]})");
                } 
                else
                {
                    logsystem.log($"[{DateTime.Now}] ERROR | Invalid arguments count {args.Count()}");
                }    
            }
        }
    }
}
