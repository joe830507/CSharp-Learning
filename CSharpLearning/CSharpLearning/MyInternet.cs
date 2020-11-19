using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;

namespace CSharpLearning
{
    public class MyInternet : IDemonstrate
    {
        public void Demonstrate()
        {
            SendDataToWebServerByHttpClient();
        }
        //301
        public void SimpleTCPCommunicationServerSide()
        {
            // for binding host:port and listen to the connection from outside.
            Socket server = new Socket(SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localSv = new IPEndPoint(IPAddress.Loopback, 6000);
            server.Bind(localSv);
            server.Listen(10);
            // for communication with client side.
            Socket client = server.Accept();
            string message = "Hello, I'm server.";
            byte[] data = Encoding.UTF8.GetBytes(message);
            client.Send(BitConverter.GetBytes(data.Length));
            client.Send(data);
            client.Close();
            server.Close();
        }
        public void SimpleTCPCommunicationClientSide()
        {
            Socket client = new Socket(SocketType.Stream, ProtocolType.Tcp);
            client.Connect(IPAddress.Loopback, 6000);
            byte[] data = new byte[sizeof(int)];
            int dataLen = 0;
            int n = client.Receive(data);
            if (n == data.Length)
            {
                dataLen = BitConverter.ToInt32(data, 0);
            }
            data = new byte[dataLen];
            client.Receive(data);
            string msg = Encoding.UTF8.GetString(data);
            Console.WriteLine($"msg:{msg}");
            client.Disconnect(false);
            client.Close();
        }
        //302
        public void TcpListenerExampleServerSide()
        {
            TcpListener server = new TcpListener(IPAddress.Any, 1763);
            server.Start();
            TcpClient client = server.AcceptTcpClient();
            using (NetworkStream stream = client.GetStream())
            {
                List<byte> data = new List<byte>();
                byte[] buffer = new byte[256];
                int n = 0;
                while ((n = stream.Read(buffer)) != 0)
                {
                    data.AddRange(buffer.Take(n));
                }
                string msg = Encoding.UTF8.GetString(data.ToArray());
                Console.WriteLine(msg);
            }
            server.Stop();
        }
        public void TcpListenerExampleClientSide()
        {
            TcpClient client = new TcpClient();
            client.Connect(IPAddress.Parse("127.0.0.1"), 1763);
            using (NetworkStream stream = client.GetStream())
            {
                string ct = ".NET Core";
                byte[] data = Encoding.UTF8.GetBytes(ct);
                stream.Write(data);
            }
        }
        //303
        public void ShowUdpClient()
        {
            UdpClientServerSide();
            while (true)
            {
            }
        }
        public async void UdpClientServerSide()
        {
            UdpClient udpServer = new UdpClient(9000);
            while (true)
            {
                UdpReceiveResult result = await udpServer.ReceiveAsync();
                string msg = Encoding.UTF8.GetString(result.Buffer);
                if (msg.ToLower().Equals("end"))
                {
                    udpServer.Close();
                    break;
                }
                string host = result.RemoteEndPoint.Address.MapToIPv4().ToString();
                Console.WriteLine($"{host}:{msg}");
            }
        }
        public void UdpClientClientSide()
        {
            UdpClient udpClient = new UdpClient();
            string serverHost = "127.0.0.1";
            int serverPort = 9000;
            while (true)
            {
                Console.WriteLine("Please type your message...");
                string msg = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(msg);
                udpClient.Send(data, data.Length, serverHost, serverPort);
                if (msg.ToLower().Equals("end"))
                    break;
            }
            udpClient.Close();
        }
        //304
        public void DownloadPicsFromWebServer()
        {
            Console.WriteLine("Please type in URL:");
            string url = Console.ReadLine();
            HttpWebRequest request = WebRequest.CreateHttp(url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream respStream = response.GetResponseStream())
            {
                using (FileStream fs = new FileStream($"D:/down.jpg", FileMode.Create))
                {
                    respStream.CopyTo(fs);
                }
            }
        }
        //305
        public void SendDataToWebServerByHttpClient()
        {
            HandleHttpClientAsync();
            while (true)
            {
                string command = Console.ReadLine();
                if (command.ToLower().Equals("end"))
                    break;
            }
        }
        public async void HandleHttpClientAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"http://www.coolpc.com.tw/phpBB2/portal.php";
                //StringContent content = new StringContent("Li", System.Text.Encoding.UTF8);
                //HttpResponseMessage response = await client.PostAsync(url, content);
                HttpResponseMessage response = await client.GetAsync(url);
                string respmsg = await response.Content.ReadAsStringAsync();
                Console.WriteLine(respmsg);
                Console.WriteLine(respmsg.Length);
            }
        }
    }
}
