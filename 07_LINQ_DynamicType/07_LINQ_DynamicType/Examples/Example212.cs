using System.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example212 : IDemonstration
    {
        public void display()
        {
            Rectangle[] rects =
            {
                new Rectangle{Width=16.002f,Height=7f},
                new Rectangle{Width=2.5f,Height=4.74f},
                new Rectangle{Width=1.5f,Height=3.5f},
                new Rectangle{Width=6.9f,Height=12.3f},
                new Rectangle{Width=0.8f,Height=10.22f},
                new Rectangle{Width=9.4f,Height=21.3f},
                new Rectangle{Width=6.5f,Height=32.8f}
            };
            int count = rects.Count(r => (r.Width * r.Height) > 100f);
            System.Console.WriteLine(">100cm2:{0}", count);
        }

        public struct Rectangle
        {
            public float Width;
            public float Height;
        }
    }
}
