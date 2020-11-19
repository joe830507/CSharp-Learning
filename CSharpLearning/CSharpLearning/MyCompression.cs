using System;
using System.IO;
using System.IO.Compression;

namespace CSharpLearning
{
    public class MyCompression : IDemonstrate
    {
        public void Demonstrate()
        {
            CompressFilesByGZipStream();
        }

        public void UsingDeflateStream()
        {
            System.Console.WriteLine("Please write down your input path.");
            string inputPath = System.Console.ReadLine();
            System.Console.WriteLine("Please write down your output path.");
            string outputPath = System.Console.ReadLine();
            using (FileStream inputStream = new FileStream(inputPath, FileMode.Open))
            using (FileStream outputStream = new FileStream(outputPath, FileMode.Create))
            using (DeflateStream ds = new DeflateStream(outputStream, CompressionLevel.Optimal))
            {
                inputStream.CopyTo(ds);
            }
            FileInfo f1 = new FileInfo(inputPath), f2 = new FileInfo(outputPath);
            System.Console.WriteLine(f1.Length);
            System.Console.WriteLine(f2.Length);
        }
        public void CreateZipFile()
        {
            string zipFile = $"D:/demo.zip";
            using (FileStream fs = File.Create(zipFile))
            {
                using (ZipArchive zip = new ZipArchive(fs, ZipArchiveMode.Create))
                {
                    ZipArchiveEntry zae1 = zip.CreateEntry($"docs/doc1.txt");
                    using (Stream stream = zae1.Open())
                    {
                        using (StreamWriter writer = new StreamWriter(stream))
                        {
                            writer.Write("example1");
                        }
                    }
                    ZipArchiveEntry zae2 = zip.CreateEntry($"docs/doc2.txt");
                    using (Stream stream = zae2.Open())
                    {
                        using (StreamWriter writer = new StreamWriter(stream))
                        {
                            writer.Write("example2");
                        }
                    }
                    ZipArchiveEntry zae3 = zip.CreateEntry($"docs/doc3.txt");
                    using (Stream stream = zae3.Open())
                    {
                        using (StreamWriter writer = new StreamWriter(stream))
                        {
                            writer.Write("example3");
                        }
                    }
                }
            }
            using (FileStream instream = File.OpenRead(zipFile))
            {
                using (ZipArchive za = new ZipArchive(instream))
                {
                    foreach (var et in za.Entries)
                    {
                        using (Stream stream = et.Open())
                        {
                            using (FileStream fsout = File.Create(et.Name))
                            {
                                stream.CopyTo(fsout);
                            }
                        }
                    }
                }
            }
        }
        public void CompressFilesByGZipStream()
        {
            System.Console.WriteLine("Please type in the input path...");
            string inFilePath = Console.ReadLine();
            string outFileName = $"D:/demo.gz";
            using (FileStream inputStream = File.OpenRead(inFilePath))
            using (FileStream outputStream = File.Create(outFileName))
            {
                using (GZipStream gzs = new GZipStream(outputStream,CompressionMode.Compress))
                {
                    inputStream.CopyTo(gzs);
                }
            }

            FileInfo f1 = new FileInfo(inFilePath);
            FileInfo f2 = new FileInfo(outFileName);
            Console.WriteLine(f1.Length);
            Console.WriteLine(f2.Length);
        }
    }
}
