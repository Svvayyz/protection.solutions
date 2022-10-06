using protection.solutions.Protection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace protection.solutions
{
    class Protector
    {
        public static List<string> blockedFiles = new List<string>();
        public static Dictionary<string, string> AdditionalDetections = new Dictionary<string, string>();

        public static void prefix(Color color)
        {
            Console.ForegroundColor = Color.White;
            Console.Write("{");
            Console.ForegroundColor = color;
            Console.Write("$");
            Console.ForegroundColor = Color.White;
            Console.Write("}");
        }
        public static void check_hash(string sha256sum, string path)
        {
            var detections = new Dictionary<string, string>(){
                {"7QHr+8nrW76lRa9NAb9fEHFmGEBIBDnG5bq+jggOQao=", "Wannacry ransomware (RED)"},
                {"JrRpmnue6xbnYwXYQ9SrBelNQ/MgFDaSfhOz66+pBzk=", "Petya ransomware (RED)"},
                {"9dACv+gLSDhqbJnEFSiTG39d9zbNNAlEY8P4Xd4BgL8=", "InfinityCrypt ransomware (RED)"},
                {"nD+N+AGTwIWRLJlQxYBRrnfDIZdXhMwGnOrNT1fVhh0=", "Powerpoint ransomware (RED)"},
                {"fTc8y5bR27GFbvMa+ofCESoMF5WnlqsByxVHACiK/sU=", "7ev3n ransomware (RED)"},
                {"stz9+eewnyqlAEZoNw53mCljrOgg5yhbLiZKKURB2iM=", "Birele ransomware (RED)"},
                {"s+Hp2X10xBbCow3RGFh4mvVVTPLeYvV3wTlEoZYjd30=", "Cerber5 ransomware (RED)"},
                {"YwMlysCaw/q5CPkD47ANDa3V/aoIde2Elvy7l6VY0No=", "Batrabbit (RED)"},
                {"T1v/ZBYARNmnaasnf/hbqVTiouGCxtpNBnJ5DPHUgwk=", "DeriaLock ransomware (RED)"},
                {"9CNKUB7c0w07wVyYNpLJRQODtzvdMQBZQFxeOkPMcws=", "Fantom ransomware (RED)"},
                {"aLDhky87RDmGW+hIwtWS1RdNvbqrj2YQSg5bKMko7gw=", "WinLocker ransomware (RED)"},
                {"OrODPjHkCDAmQhxkEwQ2ms/TG5V7eK+B88bvSWjvDhU=", "Xyeta ransomware (RED)"},
                {"558WTMx1pdXAMrTFqW1q12BPr/sor+d7wpuRc/o1Q+Q=", "Krotten ransomware (RED)"},
                {"KqsT1JtgAB3jqkf7j3JRqXP6p/PFOjhAzfX9CybpoJ8=", "NOMoreRansom ransomware (RED)"},
                {"GJjyyuHjgkyw9/1TaBcaM6uheeY1AeSAtNqeoF6/BCM=", "PolyRansom ransomware (RED)"},
                {"QYOV79JpvGU04CySyyxWhjGtpuVLxVreTkpZhmBf94Y=", "ViraLock ransomware (RED)"},
                {"0w12dqO0yRt31AP4F0jr9riCR0nbX4YOEUqKIEvKW48=", "NoEscape (RED)"},
                {"EX168N60Cz/lMrtsvjdIhPpV7Xz+BT/mmHIM3MtaWcs=", "Ana (RED)"},
                {"TqHy7PfrEolvLL+Gg9roVG0rjcQ893ENaM6Z4SfAqWY=", "000 (RED)"},
                {"77LCoaNdZMcsOP6TPBEDXj2MOEmjbss3zRDJA6QmfKY=", "ddom (RED)"},

                {"o9VxWoHy++tfdsiMnCHu7ocUKQlxZHL5Ef9pUMeQwk0=", "Memz (ORANGE)"},
                {"Vb/LeEkER372LvfkmU3uQvA9ab/sNZGYlRPMy7o/yP4=", "Spark (ORANGE)"},
                {"H2mBC4/nHjCoc4J4rfCd2YL33gq5iR0pbOfqYbP6T2k=", "YouAreAnIdiot (ORANGE)"},

                {"iFUplWAYO1dVbZcUorlYzcYZD837JwYz2ipH3+7iABU=", "Koteyeka (YELLOW)"},
                {"Ktyir+pgvcZ+4W0aoEwJuoerSbC+YWB5wIu1omET9bg=", "m3m3war3 (YELLOW)"},
                {"zLlQK/i6W+z4t1jKBKViXDC3ni0Q0md8xDrkJT4SiOw=", "Chilledwindows (YELLOW)"}
            };

            if (AdditionalDetections.Count() >= 1)
            {
                for (int i = 0; i < AdditionalDetections.Count(); i++)
                {
                    try
                    {
                        if (detections[AdditionalDetections.ElementAt(i).Key] == null) { }
                    }
                    catch (Exception)
                    {
                        detections.Add(AdditionalDetections.ElementAt(i).Key, AdditionalDetections.ElementAt(i).Value);
                    }
                }
            }

            try {
                if (detections[sha256sum] != null)
                {
                    string name = detections[sha256sum];

                    Color threatLevel = Color.Green;
                    if (name.Contains("(RED)"))
                    {
                        name = name.Replace(" (RED)", "");
                        threatLevel = Color.Red;
                    }
                    else if (name.Contains("(ORANGE)"))
                    {
                        name = name.Replace(" (ORANGE)", "");
                        threatLevel = Color.Orange;
                    }
                    else if (name.Contains("(YELLOW)"))
                    {
                        name = name.Replace(" (YELLOW)", "");
                        threatLevel = Color.Yellow;
                    }


                    Deleter.Delete(path, $"{name} deleted", "Click here for details!", name, threatLevel);
                }
            }
            catch (Exception)
            {
                Program.is_used_by_another_process = false;
            }
        }
        public static void check_extension(string extension, string path)
        {
            if (extension == ".wcry")
            {
                // blocking file fucking
                for (int i = 0; i < blockedFiles.Count; i++)
                {
                    if (blockedFiles[i] == path)
                    {

                    }
                    else
                    {
                        if (i == blockedFiles.Count)
                        {
                            blockedFiles.Add($"{path}");
                            File.Encrypt($"Files\\{Path.GetFileName($"{path}")}");
                        }
                    }
                }
            }
            else
            {
                File.Delete($"{path}");
            }
        }
    }
}
