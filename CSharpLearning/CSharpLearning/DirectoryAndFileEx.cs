using System;
using System.IO;
using System.Linq;

namespace CSharpLearning
{
    public class DirectoryAndFileEx : IDemonstrate
    {
        public void Demonstrate()
        {
            ChangeByPositionProp();
        }

        public void CreateDirectoryAndFile()
        {
            Directory.CreateDirectory("test_dir");
            var stream = File.Create("test_dir/sample.data");
            byte[] buffer = { 5, 7, 9, 11, 13 };
            stream.Write(buffer, 0, buffer.Length);
            stream.Close();
            stream.Dispose();
        }
        public void ChangeCreationTime()
        {
            string file_name = "testFile";
            using (var s = File.Create(file_name))
            {
                s.WriteByte(100);
                s.WriteByte(200);
            }
            System.Console.WriteLine(file_name);
            System.Console.WriteLine(File.GetCreationTime(file_name));
            DateTime creationTime = new DateTime(2016, 8, 16, 23, 14, 50);
            File.SetCreationTime(file_name, creationTime);
            Console.WriteLine(File.GetCreationTime(file_name));
        }
        public void CreateFileByFileInfo()
        {
            FileInfo file = new FileInfo("test_data");
            using (var s = file.Create())
            {
                s.Write(new byte[] { 55, 13, 27, 4, 16 });
            }
        }
        public void CheckFolderIfExist()
        {
            string dirName = "sample_folder";
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
        }
        public void AppendText()
        {
            string file_name = "abc.txt";
            File.AppendAllText(file_name, "Test");
            File.AppendAllText(file_name, " oh!\r\n");
            File.AppendAllText(file_name, "OMG");
            File.AppendAllText(file_name, "lalala");
        }
        public void WriteText()
        {
            string fileName = "abc.txt";
            File.WriteAllText(fileName, "First");
            File.WriteAllText(fileName, "Second");
            File.WriteAllText(fileName, "Third");
        }
        public void DeleteFileByFileInfo()
        {
            string fileName = "test";
            FileInfo info = new FileInfo(fileName);
            if (info.Exists)
            {
                info.Delete();
            }
            using (var fs = info.Create())
            {
                byte[] buffer = new byte[512];
                Random rand = new Random();
                rand.NextBytes(buffer);
                fs.Write(buffer);
            }
        }
        public void AppendAllLines()
        {
            string fileName = "D://test.txt";
            string[] lines =
            {
                "First",
                "Two",
                "Three",
                "Four"
            };
            File.AppendAllLines(fileName, lines);
        }
        public void UseMoveToRenameAFolder()
        {
            string oldName = "D://test1";
            string newName = "D://test2";
            Directory.CreateDirectory(oldName);
            Directory.Move(oldName, newName);
        }
        public void ReadAllLines()
        {
            string[] allLines = File.ReadAllLines($"D:/test.txt");
            foreach (var s in allLines)
            {
                Console.WriteLine(s);
            }
        }

        public void MakeFiles()
        {
            Random r = new Random();
            for (int i = 0; i < 20; i++)
            {
                int bufferLen = r.Next(10, 99999);
                byte[] buffer = new byte[bufferLen];
                r.NextBytes(buffer);
                using (FileStream fs = File.Create($"D:/demo_{ i + 1 }"))
                {
                    fs.Write(buffer);
                }
            }
        }

        public void OrderByFileSize()
        {
            MakeFiles();
            DirectoryInfo dir = new DirectoryInfo($"D:/");
            var q = from f in dir.EnumerateFiles("demo_*")
                    orderby f.Length
                    select (FileName: f.Name, FileSize: f.Length);
            foreach (var file in q)
            {
                Console.WriteLine($"FileName:{file.FileName}, FileSize:{file.FileSize}");
            }
        }
        public void EnumDrive()
        {
            DriveInfo[] drs = DriveInfo.GetDrives();
            var q = from d in drs
                    where d.IsReady
                    select d;
            foreach (var di in q)
            {
                Console.WriteLine($"DriveName:{di.Name}");
                Console.WriteLine($"Label:{di.VolumeLabel}");
                Console.WriteLine($"TotalSize:{di.TotalSize}");
                Console.WriteLine($"TotalFreeSpace:{di.TotalFreeSpace}");
                Console.WriteLine($"DriveType:{di.DriveType}");
                Console.WriteLine($"DriveFormat:{di.DriveFormat}");
                Console.WriteLine($"RootDirectory:{di.RootDirectory.Name}");
                Console.WriteLine();
            }
        }
        public void MemoryStream()
        {
            byte[] buffer = { 155, 16, 3, 200, 77, 9, 21, 34, 60 };
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(buffer);
            }
        }
        public void ReadContentFromMemory()
        {
            using (MemoryStream ms = GetMemory())
            {
                byte[] buffer = new byte[ms.Length];
                ms.Read(buffer, 0, buffer.Length);
                Console.WriteLine($"Contnet:{BitConverter.ToString(buffer)}.");
            }
        }
        public MemoryStream GetMemory()
        {
            MemoryStream ms = new MemoryStream();
            ms.WriteByte(1);
            ms.WriteByte(2);
            ms.WriteByte(3);
            ms.WriteByte(4);
            ms.WriteByte(5);
            ms.Position = 0;
            return ms;
        }
        public void TestStreamReader()
        {
            using (StreamWriter sw = new StreamWriter($"D://test.txt"))
            {
                sw.WriteLine("12312312312");
                sw.WriteLine(213228390L);
                sw.WriteLine(213.29132d);
            }

            using (StreamReader sr = new StreamReader($"D://test.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine(sr.ReadToEnd());
            }
        }
        public void CallSeekFunToResetCurrentPosition()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                for (byte i = 0; i <= 8; i++)
                {
                    ms.WriteByte(i);
                    Console.WriteLine(" 0x:{0:x2}", i);
                }
                Console.WriteLine("------------");
                ms.Seek(-3, SeekOrigin.End);
                int r;
                while ((r = ms.ReadByte()) != -1)
                {
                    Console.WriteLine(" 0x:{0:x2}", r);
                }
            }
        }
        public void ChangeByPositionProp()
        {
            using (FileStream fs = new FileStream($"D:/demo.txt", FileMode.OpenOrCreate))
            {
                Random rd = new Random();
                byte[] data = new byte[10];
                rd.NextBytes(data);
                fs.Write(data);
            }

            using (FileStream fs = new FileStream($"D:/demo.txt", FileMode.Open))
            {
                fs.Position = 5L;
                byte[] buffer = new byte[fs.Length - fs.Position];
                fs.Read(buffer, 0, buffer.Length);
                Console.WriteLine(BitConverter.ToString(buffer));
            }
        }
    }
}
