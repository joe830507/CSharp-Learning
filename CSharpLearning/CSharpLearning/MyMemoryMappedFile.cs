using System.IO;
using System.IO.MemoryMappedFiles;

namespace CSharpLearning
{
    public class MyMemoryMappedFile : IDemonstrate
    {
        public void Demonstrate()
        {
            CallCreateFromFile();
        }

        public void ReadAndWriteFileByMemoryMappedFile()
        {
            MemoryMappedFile file = MemoryMappedFile.CreateNew("test", 2000L);
            using (var mvstream = file.CreateViewStream())
            {
                using (StreamWriter sw = new StreamWriter(mvstream))
                {
                    sw.WriteLine("This is a sentence.");
                }
            }

            using (MemoryMappedFile mfile = MemoryMappedFile.OpenExisting("test"))
            {
                using (var vstream = mfile.CreateViewStream())
                {
                    using (StreamReader reader = new StreamReader(vstream))
                    {
                        string str = reader.ReadLine();
                        System.Console.WriteLine(str);
                    }
                }
            }
        }
        public void CallCreateFromFile()
        {
            using (MemoryMappedFile mmfile = MemoryMappedFile.CreateFromFile("demo.data", FileMode.OpenOrCreate, "demo", 100L))
            {
                using (var vstream = mmfile.CreateViewStream())
                {
                    using (BinaryWriter writer = new BinaryWriter(vstream))
                    {
                        writer.Write(160);
                        writer.Write(1.27f);
                        writer.Write(900000L);
                        writer.Write(13.45d);
                    }
                }
            }

            using (FileStream stream = File.OpenRead("demo.data"))
            {
                System.Console.WriteLine(stream.Length);
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    var v1 = reader.ReadInt32();
                    var v2 = reader.ReadSingle();
                    var v3 = reader.ReadInt64();
                    var v4 = reader.ReadDouble();
                    System.Console.WriteLine(v1);
                    System.Console.WriteLine(v2);
                    System.Console.WriteLine(v3);
                    System.Console.WriteLine(v4);
                }
            }
        }
    }
}
