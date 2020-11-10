namespace CSharpLearning
{
    public class AnonymousExample : IDemonstrate
    {
        public void Demonstrate()
        {
            var x = new
            {
                City = "Taipei",
                Phone = "0987654321",
                Number = 12345,
                Size = 12.554f
            };
            System.Console.WriteLine($"City:{x.City},Phone:{x.Phone},Number:{x.Number},Size:{x.Size}");
        }
    }
}
