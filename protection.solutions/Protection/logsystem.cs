using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace protection.solutions
{
    class logsystem
    {
        public static void log(string text)
        {
            if(!File.Exists("logs.log"))
            {
                File.Create("logs.log");
            }
            try
            {
                File.AppendAllText("logs.log", text + "\n");
            }
            catch (Exception)
            {

            }
        }
    }
}
