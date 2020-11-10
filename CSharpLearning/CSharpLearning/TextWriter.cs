using System;
using System.IO;
using System.Text;

namespace CSharpLearning
{
    public class TextWriter : IDisposable
    {

        const string FILE_NAME = "demo.txt";

        FileStream fsWriter = null;

        public TextWriter()
        {
            fsWriter = File.OpenWrite(FILE_NAME);
        }

        public void WriteText(string str)
        {
            byte[] data = Encoding.UTF8.GetBytes(str);
            fsWriter.Write(data, 0, data.Length);
            fsWriter.Flush();
        }

        public void Dispose()
        {
            fsWriter?.Close();
            fsWriter?.Dispose();
        }
    }
}
