namespace CSharpLearning
{
    public class NetworkManager : IDownloader, IUploader
    {
        void IDownloader.Start()
        {
            System.Console.WriteLine("Downloading...");
        }
        void IUploader.Start()
        {
            System.Console.WriteLine("Uploading...");
        }
    }
}
