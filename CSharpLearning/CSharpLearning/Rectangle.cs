using System;

namespace CSharpLearning
{
    public partial class Program
    {
        public class Rectangle
        {
            public float Width;
            public float Height;

            public Rectangle(double width, double height)
            {
                Width = (float)width;
                Height = (float)height;
            }

            public double Diagnoal
            {
                get
                {
                    double qw = Math.Pow(Width, 2d);
                    double qh = Math.Pow(Height, 2d);
                    double res = Math.Sqrt(qw + qh);
                    return res;
                }
            }
        }
    }
}
