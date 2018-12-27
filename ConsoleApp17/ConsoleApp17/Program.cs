using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    class Program
    {
        static void Main(string[] args)
        {

            NVALog.FileW();
            LogFileSearch.SearchName();
            LogFileSearch.SearchDay();
            LogFileSearch.SearchTime();
            LogFileSearch.LastHourOnly();
            Console.ReadKey();
        }
    }
    class NVALog
    {
        static StreamWriter wr = new StreamWriter(@"D:\nvalog.txt");
        public static void FileW()
        {
            try
            {

                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = @"D:\";
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.CreationTime;
                watcher.Filter = "*.*";
                watcher.Created += new FileSystemEventHandler(OnCreated);
                watcher.Deleted += new FileSystemEventHandler(OnDeleted);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.EnableRaisingEvents = true;
                Console.WriteLine("Задание 2");
                NVADiskInfo.Info();
                Console.WriteLine("Задание 3");
                NVAFileInfo.Info();
                Console.WriteLine("Задание 4");
                NVADirInfo.Info();
                Console.WriteLine("Задание 5");
                NVAFileManager.A();
                NVAFileManager.B();
                NVAFileManager.C();
                watcher.EnableRaisingEvents = false;
                wr.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void OnCreated(object sendler, FileSystemEventArgs e)
        {
            wr.WriteLine("Имя: " + e.Name);
            wr.WriteLine("Действие: " + e.ChangeType);
            wr.WriteLine("Путь к файлу^ " + e.FullPath);
            wr.WriteLine("Время: " + DateTime.Now);
            wr.WriteLine();
        }
        public static void OnDeleted(object sendler, FileSystemEventArgs e)
        {
            wr.WriteLine("Имя: " + e.Name);
            wr.WriteLine("Действие: " + e.ChangeType);
            wr.WriteLine("Путь к файлу^ " + e.FullPath);
            wr.WriteLine("Время: " + DateTime.Now);
            wr.WriteLine();
        }

        public static void OnRenamed(object sendler, FileSystemEventArgs e)
        {
            wr.WriteLine("Имя: " + e.Name);
            wr.WriteLine("Действие: " + e.ChangeType);
            wr.WriteLine("Путь к файлу^ " + e.FullPath);
            wr.WriteLine("Время: " + DateTime.Now);
            wr.WriteLine();
        }

        public static void OnChanged(object sendler, FileSystemEventArgs e)
        {
            wr.WriteLine("Имя: " + e.Name);
            wr.WriteLine("Действие: " + e.ChangeType);
            wr.WriteLine("Путь к файлу^ " + e.FullPath);
            wr.WriteLine("Время: " + DateTime.Now);
            wr.WriteLine();
        }
    }
    class NVADiskInfo
    {
        static DriveInfo[] drives = DriveInfo.GetDrives();
        public static void Info()
        {
            int i = 0;
            foreach (DriveInfo drive in drives)
            { if (i < 2) { 
                    Console.WriteLine("Имя диска:" + drive.Name);
                Console.WriteLine("Имя файловой системы:" + drive.DriveFormat);
                Console.WriteLine("Объём диска:" + drive.TotalSize);
                Console.WriteLine("Количество места на диске:" + drive.AvailableFreeSpace);
                Console.WriteLine("Метка диска:" + drive.VolumeLabel);
                    i++;
                    }
            }
        }
        
    }
    class NVAFileInfo
    {
        public static void Info()
        {
            try
            {
                Console.WriteLine("Введите путь к файлу, информацию о котором хотите просмотреть...");
                string s = Console.ReadLine();
                FileInfo file = new FileInfo(s);
                Console.WriteLine("Имя файла: " + file.Name);
                Console.WriteLine("размер файла: " + file.Length + " байт");
                Console.WriteLine("расширение файла: " + file.Extension);
                Console.WriteLine("Полный путь: " + file.FullName);
                Console.WriteLine("Время создания: " + file.CreationTime);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
    class NVADirInfo
    {
        public static void Info()
        {
            try
            {
                Console.WriteLine("Введите путь директория...");
                string str = Console.ReadLine();
                DirectoryInfo dir = new DirectoryInfo(str);
                Console.WriteLine("Полное имя директория: " + dir.FullName);
                Console.WriteLine("Время создания: " + dir.CreationTime);
                Console.WriteLine("Количество файлов: " + dir.EnumerateFiles().Count());
                Console.WriteLine("Количество поддиректориев: " + dir.EnumerateDirectories().Count());
                Console.WriteLine("Родительский директорий: " + dir.Root);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
    class NVAFileManager
    {
        static DriveInfo drive = new DriveInfo(@"D:\");
        static DirectoryInfo dir;
        static string[] files = Directory.GetFiles(@"D:\");
        static string[] directories = Directory.GetDirectories(@"D:\");
        static FileInfo file;

        public static void A()
        {
            try
            {
                dir = Directory.CreateDirectory(@"D:\lab13");
                file = new FileInfo(@"D:\lab13\nvainfo.txt");
                using (StreamWriter writer = new StreamWriter(@"D:\lab13\nvainfo.txt"))
                {
                    writer.WriteLine("Список директоиев диска D:");
                    foreach (string s in directories)
                        writer.WriteLine(s);
                    writer.WriteLine();
                    writer.WriteLine("Список файлов диска D:");
                    foreach (string s in files)
                        writer.WriteLine(s);
                    writer.WriteLine();
                }
                file.CopyTo(@"D:\lab13\nvainfo_copy.txt", true);
                file.Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        public static void B()
        {
            try
            {
                dir = Directory.CreateDirectory(@"D:\lab13_1");
                DirectoryInfo d = new DirectoryInfo(@"D:\Hello");
                FileInfo[] file = d.GetFiles("*.txt*");
                for (int i = 0; i < file.Length; i++)
                    file[i].CopyTo(@"D:\lab13_1\" + file[i].Name, true);
                d = new DirectoryInfo(@"D:\lab13_1");
                d.MoveTo(@"D:\lab13\lab13_1");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        public static void C()
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(@"D:\lab13\lab13_1");
                FileInfo[] Fil = directory.GetFiles("*");
               
                ZipFile.CreateFromDirectory(@"D:\lab13\lab13_1", @"D:\lab13\lab13_1.zip");
                ZipFile.ExtractToDirectory(@"D:\lab13\lab13_1", @"D:\");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
    class LogFileSearch
    {
        static int count;
        static StreamReader streamreader = new StreamReader(@"D:\nvalog.txt");
        static string line;
        static string[] LogBlock = new string[5];
        public static void SearchName()
        {
            Console.WriteLine("Введите имя для поиска по имени (например laba12.txt)...");
            string name = Console.ReadLine();
            Console.WriteLine($"Поиск по имени <{name}>");
            bool check = false;
            while (!streamreader.EndOfStream)
            {
                LogBlock[0] = streamreader.ReadLine();
                LogBlock[1] = streamreader.ReadLine();
                LogBlock[2] = streamreader.ReadLine();
                LogBlock[3] = streamreader.ReadLine();
                LogBlock[4] = streamreader.ReadLine();
                check = true;
                if (check)
                {
                    line = LogBlock[0];
                    line = line.Substring(line.IndexOf(' ') + 1);
                    if (line == name)
                    {
                        Console.WriteLine(LogBlock[0]);
                        Console.WriteLine(LogBlock[1]);
                        Console.WriteLine(LogBlock[2]);
                        Console.WriteLine(LogBlock[3]);
                        Console.WriteLine(LogBlock[4]);
                        check = false;
                    }
                }
            }
            streamreader.Close();
        }
        public static void SearchDay()
        {
            streamreader = new StreamReader(@"D:\nvalog.txt");
            Console.WriteLine("Укажите дату для поиска (например 23)...");
            string name = Console.ReadLine();
            Console.WriteLine($"Поиск по дате <{name}>");
            bool check = false;
            while (!streamreader.EndOfStream)
            {
                LogBlock[0] = streamreader.ReadLine();
                LogBlock[1] = streamreader.ReadLine();
                LogBlock[2] = streamreader.ReadLine();
                LogBlock[3] = streamreader.ReadLine();
                LogBlock[4] = streamreader.ReadLine();
                check = true;
                if (check)
                {
                    line = LogBlock[3];
                    line = line.Substring(line.IndexOf(' ') + 1, 2);
                    if (line == name)
                    {
                        Console.WriteLine(LogBlock[0]);
                        Console.WriteLine(LogBlock[1]);
                        Console.WriteLine(LogBlock[2]);
                        Console.WriteLine(LogBlock[3]);
                        Console.WriteLine(LogBlock[4]);
                        check = false;
                    }
                }
            }
            streamreader.Close();
        }
        public static void SearchTime()
        {
            streamreader = new StreamReader(@"D:\nvalog.txt");
            Console.WriteLine("Введите время time1 (например 15)...");
            string time1 = Console.ReadLine();
            Console.WriteLine("Введите время time2 (например 23)...");
            string time2 = Console.ReadLine();
            Console.WriteLine($"Поиск по времени <{time1} - {time2}>");
            bool check = false;
            while (!streamreader.EndOfStream)
            {
                LogBlock[0] = streamreader.ReadLine();
                LogBlock[1] = streamreader.ReadLine();
                LogBlock[2] = streamreader.ReadLine();
                LogBlock[3] = streamreader.ReadLine();
                LogBlock[4] = streamreader.ReadLine();
                count++;
                check = true;
                if (check)
                {
                    line = LogBlock[3];
                    line = line.Substring(line.IndexOf(' ') + 1);
                    line = line.Substring(line.IndexOf(' ') + 1);
                    line = line.Substring(line.IndexOf(' ') + 1, line.IndexOf(':') - (line.IndexOf(' ') + 1));
                    if (Convert.ToInt32(time1) <= Convert.ToInt32(line) && Convert.ToInt32(time2) >= Convert.ToInt32(line))
                    {
                        Console.WriteLine(LogBlock[0]);
                        Console.WriteLine(LogBlock[1]);
                        Console.WriteLine(LogBlock[2]);
                        Console.WriteLine(LogBlock[3]);
                        Console.WriteLine(LogBlock[4]);
                        check = false;
                    }
                }
            }
            streamreader.Close();
           Console.WriteLine("Количество записей: " + count);
        }
        public static void LastHourOnly()
        {
            streamreader = new StreamReader(@"D:\nvalog.txt");
            List<string> ListLog = new List<string>();
            List<string> ListLogResult = new List<string>();
            DateTime time = DateTime.Now;
            int Hour = time.Hour;
            string Date = time.Day + "." + time.Month + "." + time.Year;
            string line, line2;
            while (!streamreader.EndOfStream)
            {
                ListLog.Add(streamreader.ReadLine());
            }
            streamreader.Close();
            for (int i = 0; i < ListLog.Count; i++)
            {
                if (ListLog[i].Contains("Время"))
                {
                    line = ListLog[i];
                    line = line.Substring(line.IndexOf(' ') + 1);
                    line2 = line.Substring(0, line.IndexOf(' '));
                    line = line.Substring(line.IndexOf(' ') + 1);
                    line = line.Substring(line.IndexOf(' ') + 1, line.IndexOf(':') - (line.IndexOf(' ') + 1));
                    if (Hour == Convert.ToInt32(line) && Date == line2)
                    {
                        ListLogResult.Add(ListLog[i - 3]);
                        ListLogResult.Add(ListLog[i - 2]);
                        ListLogResult.Add(ListLog[i - 1]);
                        ListLogResult.Add(ListLog[i]);
                        ListLogResult.Add(ListLog[i + 1]);
                    }
                }
            }
            StreamWriter writer = new StreamWriter(@"D:\nvalog.txt");
            for (int i = 0; i < ListLogResult.Count; i++)
                writer.WriteLine(ListLogResult[i]);
            writer.Close();
        }
    }
}
