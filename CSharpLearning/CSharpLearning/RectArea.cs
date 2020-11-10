namespace CSharpLearning
{
    public partial class Program
    {
        public class RectArea
        {
            public RectArea(int width, int height)
            {
                Width = width;
                Height = height;
            }

            public int Width { get; }
            public int Height { get; }

            public static implicit operator int(RectArea r)
            {
                return r.Width * r.Height;
            }
        }
    }
}
