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
            // TODO: AUTOMATE ENTIRE DETECTION SYSTEM

            // high danger level viruses
            if (sha256sum == "7QHr+8nrW76lRa9NAb9fEHFmGEBIBDnG5bq+jggOQao=")
            {
                Deleter.Delete(path, "Wannacry ransomware deleted", "Click here for details!", "Wannacry ransomware", Color.Red);
            }
            else if (sha256sum == "JrRpmnue6xbnYwXYQ9SrBelNQ/MgFDaSfhOz66+pBzk=")
            {
                Deleter.Delete(path, "Petya ransomware deleted", "Click here for details!", "Petya ransomware", Color.Red);
            }
            else if (sha256sum == "9dACv+gLSDhqbJnEFSiTG39d9zbNNAlEY8P4Xd4BgL8=")
            {
                Deleter.Delete(path, "InfinityCrypt ransomware deleted", "Click here for details!", "InfinityCrypt ransomware", Color.Red);
            }
            else if (sha256sum == "nD+N+AGTwIWRLJlQxYBRrnfDIZdXhMwGnOrNT1fVhh0=")
            {
                Deleter.Delete(path, "Powerpoint ransomware deleted", "Click here for details!", "Powerpoint ransomware", Color.Red);
            }
            else if (sha256sum == "fTc8y5bR27GFbvMa+ofCESoMF5WnlqsByxVHACiK/sU=")
            {
                Deleter.Delete(path, "7ev3n ransomware deleted", "Click here for details!", "7ev3n ransomware", Color.Red);
            }
            else if (sha256sum == "stz9+eewnyqlAEZoNw53mCljrOgg5yhbLiZKKURB2iM=")
            {
                Deleter.Delete(path, "Birele ransomware deleted", "Click here for details!", "Birele ransomware", Color.Red);
            }
            else if (sha256sum == "s+Hp2X10xBbCow3RGFh4mvVVTPLeYvV3wTlEoZYjd30=")
            {
                Deleter.Delete(path, "Cerber5 ransomware deleted", "Click here for details!", "Cerber5 ransomware", Color.Red);
            }
            else if (sha256sum == "YwMlysCaw/q5CPkD47ANDa3V/aoIde2Elvy7l6VY0No=")
            {
                Deleter.Delete(path, "Batrabbit ransomware deleted", "Click here for details!", "Batrabbit ransomware", Color.Red);
            }
            else if (sha256sum == "T1v/ZBYARNmnaasnf/hbqVTiouGCxtpNBnJ5DPHUgwk=")
            {
                Deleter.Delete(path, "DeriaLock ransomware deleted", "Click here for details!", "DeriaLock ransomware", Color.Red);
            }
            else if (sha256sum == "9CNKUB7c0w07wVyYNpLJRQODtzvdMQBZQFxeOkPMcws=")
            {
                Deleter.Delete(path, "Fantom ransomware deleted", "Click here for details!", "Fantom ransomware", Color.Red);
            }
            else if (sha256sum == "aLDhky87RDmGW+hIwtWS1RdNvbqrj2YQSg5bKMko7gw=")
            {
                Deleter.Delete(path, "WinLocker ransomware deleted", "Click here for details!", "WinLocker ransomware", Color.Red);
            }
            else if (sha256sum == "OrODPjHkCDAmQhxkEwQ2ms/TG5V7eK+B88bvSWjvDhU=")
            {
                Deleter.Delete(path, "Xyeta ransomware deleted", "Click here for details!", "Xyeta ransomware", Color.Red);
            }
            else if (sha256sum == "558WTMx1pdXAMrTFqW1q12BPr/sor+d7wpuRc/o1Q+Q=")
            {
                Deleter.Delete(path, "Krotten ransomware deleted", "Click here for details!", "Krotten ransomware", Color.Red);
            }
            else if (sha256sum == "KqsT1JtgAB3jqkf7j3JRqXP6p/PFOjhAzfX9CybpoJ8=")
            {
                Deleter.Delete(path, "NOMoreRansom ransomware deleted", "Click here for details!", "NOMoreRansom ransomware", Color.Red);
            }
            else if (sha256sum == "GJjyyuHjgkyw9/1TaBcaM6uheeY1AeSAtNqeoF6/BCM=")
            {
                Deleter.Delete(path, "PolyRansom ransomware deleted", "Click here for details!", "PolyRansom ransomware", Color.Red);
            }
            else if (sha256sum == "QYOV79JpvGU04CySyyxWhjGtpuVLxVreTkpZhmBf94Y=")
            {
                Deleter.Delete(path, "ViraLock ransomware deleted", "Click here for details!", "ViraLock ransomware", Color.Red);
            }
            // trojans
            else if (sha256sum == "0w12dqO0yRt31AP4F0jr9riCR0nbX4YOEUqKIEvKW48=")
            {
                Deleter.Delete(path, "NoEscape deleted", "Click here for details!", "NoEscape", Color.Red);
            }
            else if (sha256sum == "EX168N60Cz/lMrtsvjdIhPpV7Xz+BT/mmHIM3MtaWcs=")
            {
                Deleter.Delete(path, "Ana deleted", "Click here for details!", "Ana", Color.Red);
            }
            else if (sha256sum == "TqHy7PfrEolvLL+Gg9roVG0rjcQ893ENaM6Z4SfAqWY=")
            {
                Deleter.Delete(path, "000 deleted", "Click here for details!", "000", Color.Red);
            }
            else if (sha256sum == "77LCoaNdZMcsOP6TPBEDXj2MOEmjbss3zRDJA6QmfKY=")
            {
                Deleter.Delete(path, "ddom deleted", "Click here for details!", "ddom", Color.Red);
            }
            // medium danger tier viruses (such as memz or koteyeka)
            else if (sha256sum == "o9VxWoHy++tfdsiMnCHu7ocUKQlxZHL5Ef9pUMeQwk0=")
            {
                Deleter.Delete(path, "Memz deleted", "Click here for details!", "Memz", Color.Orange);
            }
            else if (sha256sum == "Vb/LeEkER372LvfkmU3uQvA9ab/sNZGYlRPMy7o/yP4=")
            {
                Deleter.Delete(path, "Spark deleted", "Click here for details!", "Spark", Color.Orange);
            }
            else if (sha256sum == "H2mBC4/nHjCoc4J4rfCd2YL33gq5iR0pbOfqYbP6T2k=")
            {
                Deleter.Delete(path, "YouAreAnIdiot deleted", "Click here for details!", "YouAreAnIdiot", Color.Orange);
            }
            else if (sha256sum == "iFUplWAYO1dVbZcUorlYzcYZD837JwYz2ipH3+7iABU=")
            {
                Deleter.Delete(path, "Koteyeka deleted", "Click here for details!", "Koteyeka", Color.Orange);
            }
            // token grabbers
            else if (sha256sum == "sWl+hcVqVKBkmFQiF+E/wptj4Mds+AY37bZR5G5HKr4=")
            {
                Deleter.Delete(path, "Autentyk's token grabber deleted", "Click here for details!", "Autentyk's token grabber", Color.Orange);
            }
            // low danger tier viruses ( memes )
            else if (sha256sum == "Ktyir+pgvcZ+4W0aoEwJuoerSbC+YWB5wIu1omET9bg=")
            {          
                Deleter.Delete(path, "m3m3war3 deleted", "Click here for details!", "m3m3war3", Color.Yellow);
            }
            else if (sha256sum == "zLlQK/i6W+z4t1jKBKViXDC3ni0Q0md8xDrkJT4SiOw=")
            {
                Deleter.Delete(path, "Chilledwindows deleted", "Click here for details!", "Chilledwindows", Color.Yellow);
            }
            else
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
