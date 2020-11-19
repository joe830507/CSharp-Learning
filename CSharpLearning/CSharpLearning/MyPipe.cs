using System;
using System.IO;
using System.IO.Pipes;

namespace CSharpLearning
{
    public class MyPipe : IDemonstrate
    {
        public void Demonstrate()
        {
            SingleDirectionClientStream();
        }

        public void MyNamedPipeServerStream()
        {
            using (NamedPipeServerStream server = new NamedPipeServerStream("demo"))
            {
                System.Console.WriteLine("Quit");
                Console.Read();
                server.WaitForConnection();
                try
                {
                    using (StreamReader reader = new StreamReader(server))
                    {
                        string msg = null;
                        while ((msg = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(msg);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public void MyNamedPipeClientStream()
        {
            using (NamedPipeClientStream client = new NamedPipeClientStream("demo"))
            {
                client.Connect();
                using (StreamWriter writer = new StreamWriter(client))
                {
                    writer.AutoFlush = true;
                    while (true)
                    {
                        Console.WriteLine("Please type in your message...");
                        string msg = Console.ReadLine();
                        if (!String.IsNullOrEmpty(msg))
                        {
                            writer.WriteLine(msg);
                        }
                    }
                }
            }
        }
        public void SingleDirectionServerStream()
        {
            using (NamedPipeServerStream server = new NamedPipeServerStream("test", PipeDirection.Out))
            {
                server.WaitForConnection();
                try
                {
                    using (StreamWriter writer = new StreamWriter(server))
                    {
                        writer.AutoFlush = true;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Type in \"end\" to quit.");
                        Console.ResetColor();
                        while (true)
                        {
                            Console.WriteLine("Please type in your message.");
                            string msg = Console.ReadLine();
                            if (msg.ToLower() == "end")
                                break;
                            writer.WriteLine(msg);
                            server.WaitForPipeDrain();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public void SingleDirectionClientStream()
        {
            using (NamedPipeClientStream client = new NamedPipeClientStream(".", "test", PipeDirection.In))
            {
                client.Connect();
                using (StreamReader reader = new StreamReader(client))
                {
                    string msg = null;
                    while ((msg = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(msg);
                    }
                }
            }
        }
    }
}
