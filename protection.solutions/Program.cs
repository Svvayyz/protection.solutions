using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace protection.solutions
{
    class Program
    {
        // public variables
        public static bool debug = true;
        public static bool ransomware_protector = true;
        public static bool logs_enabled = true;
        public static bool is_used_by_another_process = false;
        public static string used_path = "";
        // main
        static void Main(string[] args)
        {
            configsystem.load();
            // Printing ascii
            Console.WriteAscii("Protection.solutions", Color.DeepSkyBlue);
            #region FileWatcher
            var watcher = new FileSystemWatcher(@"C:\");
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Renamed += OnRename;
            watcher.Changed += OnEdit;
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
            #endregion
            // Anti instant console closing 
            Console.ReadLine();
        }
        // getting sha256sum
        
        public static string SHA256CheckSum(string filePath)
        {
            using (SHA256 SHA256 = SHA256Managed.Create())
            {
                try
                {
                    using (FileStream fileStream = File.OpenRead(filePath))
                        return Convert.ToBase64String(SHA256.ComputeHash(fileStream));
                }
                catch (Exception)
                {
                    Timer t = new Timer(backup, 5, 0, 1);
                    is_used_by_another_process = true;
                    used_path = $"{filePath}";
                    return "windows is dumb";
                }
            }
        }
        private static void backup(Object state)
        {
            if (is_used_by_another_process)
            {
                string protector = SHA256CheckSum($"{used_path}");
                Protector.check_hash(protector, used_path);
                Thread.Sleep(1000);
            }
        }
        // prefix
        public static void prefix(Color color)
        {
            Console.ForegroundColor = Color.White;
            Console.Write("{");
            Console.ForegroundColor = color;
            Console.Write("$");
            Console.ForegroundColor = Color.White;
            Console.Write("}");
        }
        // on file create
        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            // variables
            string sha256sum = SHA256CheckSum($"{e.FullPath}");
            string extension = Path.GetExtension($"{e.FullPath}").ToLower();
            Protector.check_hash(sha256sum, e.FullPath);
            // debug data
            if (debug == true)
            {
                prefix(Color.Green);
                Console.Write($" File Created: {e.FullPath}\n");
            }
            // logs
            if (logs_enabled)
            {
                logsystem.log($"[{DateTime.Now}] File Deleted | ({e.FullPath}) SHA256SUM: {sha256sum}");
            }
        }
        // on file delete
        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            if (debug == true)
            {
                prefix(Color.Red);
                Console.Write($" File Deleted: {e.FullPath} \n");
            }
            // logs
            if (logs_enabled)
            {
                string sha256sum = SHA256CheckSum(e.FullPath);
                logsystem.log($"[{DateTime.Now}] File Deleted | ({e.FullPath})");
            }
        }
        // on file rename
        private static void OnRename(object sender, FileSystemEventArgs e)
        {
            // debug data
            if (debug == true)
            {
                prefix(Color.Yellow);
                Console.Write($" File Renamed: {e.FullPath} \n");
            }
            // logs
            if (logs_enabled)
            {
                string sha256sum = SHA256CheckSum(e.FullPath);
                logsystem.log($"[{DateTime.Now}] File Renamed | ({e.FullPath})");
            }
        }
        // on file edit
        private static void OnEdit(object sender, FileSystemEventArgs e)
        {
            string sha256sum = SHA256CheckSum(e.FullPath);
            Protector.check_hash(sha256sum, e.FullPath);
            // anti ransomware
            if (ransomware_protector)
            {
                if (!Directory.Exists("Files"))
                {
                    Directory.CreateDirectory("Files");
                }
                try
                {
                    string extension = Path.GetExtension($"{e.FullPath}");
                    string gotopath = $"Files\\{ Path.GetFileName(e.FullPath)}";
                    File.Copy($"{e.FullPath}", gotopath);
                    Protector.check_extension(extension, gotopath);
                }
                catch (Exception)
                {

                }
            }
            // debug info
            if (debug)
            {
                prefix(Color.Orange);
                Console.Write($" File Edited: {e.FullPath} \n");
            }
            // logs
            if (logs_enabled)
            {
                logsystem.log($"[{DateTime.Now}] File Edited | ({e.FullPath}) SHA256SUM: {sha256sum}");
            }   
        }
        // end
    }
}
