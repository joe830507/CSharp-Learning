namespace CSharpLearning
{
    class AnsymnousDelegate
    {
        delegate void Test(double f, double g);

        public static void Demonstrate()
        {
            Test td = null;
            td += delegate (double x, double y) {
                System.Console.WriteLine($"{x} + {y} = {x + y}");
            };

            td += delegate (double x, double y) {
                System.Console.WriteLine($"{x} - {y} = {x - y}");
            };

            td += delegate (double x, double y) {
                System.Console.WriteLine($"{x} x {y} = {x * y}");
            };

            td(0.3d, 0.2d);
        }
    }
}
