using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace CSharpLearning
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            IDemonstrate id = new DirectoryAndFileEx();
            id.Demonstrate();
        }
    }

    public class DirectoryAndFileEx : IDemonstrate
    {
        public void Demonstrate()
        {
            ReadAllLines();
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
    }
}
