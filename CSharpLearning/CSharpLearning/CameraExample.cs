using System;

namespace CSharpLearning
{
    public class CameraExample
    {
        public static void Demonstrate()
        {
            Camera c = Camera.CurrentInstance;
            Console.WriteLine($"DeviceId:{c.DeviceId}");
        }
    }
}
