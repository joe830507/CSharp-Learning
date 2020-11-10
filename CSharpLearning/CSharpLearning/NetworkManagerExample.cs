namespace CSharpLearning
{
    public class NetworkManagerExample : IDemonstrate
    {
        public void Demonstrate()
        {
            NetworkManager nm = new NetworkManager();
            IDownloader id = nm;
            id.Start();
            IUploader ip = nm;
            ip.Start();
        }
    }
}
