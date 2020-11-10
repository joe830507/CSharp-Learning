using System;
using System.Text;

namespace CSharpLearning
{
    public class ArrayMultiDimenEx : IDemonstrate
    {
        public void Demonstrate()
        {
            CreateTwoDimension();
            CreateThreeDimension();
            CreateArrayInstance();
            Resize();
            Reverse();
        }

        private void Reverse()
        {
            string[] str = { "ab", "cd", "ef", "gh", "ij" };
            int[] a = { 1, 2, 3, 4, 5, 6, 7 };
            Array.Reverse(str);
            foreach (var s in str)
            {
                Console.WriteLine(s);
            }
            Array.Reverse(a, 2, 3);
            foreach (var num in a)
            {
                Console.WriteLine(num);
            }
        }

        private void Resize()
        {
            int[] iArr = new int[3] { 1, 2, 3 };
            Console.WriteLine("old:" + iArr.Length);
            Array.Resize<int>(ref iArr, 5);
            Console.WriteLine("new:" + iArr.Length);
        }

        private void CreateTwoDimension()
        {
            float[,] f = new float[5, 3];
            f[0, 0] = 0.111f;
            f[0, 1] = 0.112f;
            f[0, 2] = 0.113f;
            f[1, 0] = 0.211f;
            f[1, 1] = 0.212f;
            f[1, 2] = 0.213f;
            f[2, 0] = 0.311f;
            f[2, 1] = 0.312f;
            f[2, 2] = 0.313f;
            f[3, 0] = 0.411f;
            f[3, 1] = 0.412f;
            f[3, 2] = 0.413f;
            f[4, 0] = 0.511f;
            f[4, 1] = 0.512f;
            f[4, 2] = 0.513f;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    System.Console.WriteLine("{0}", f[i, j]);
                }
            }
        }

        private void CreateThreeDimension()
        {
            int[,,] a =
            {
                {
                    { 1,2,3}
                },
                {
                    { 4,5,6}
                }
            };

            int len1 = a.GetLength(0);
            int len2 = a.GetLength(1);
            int len3 = a.GetLength(2);
            Console.WriteLine(len1);
            Console.WriteLine(len2);
            Console.WriteLine(len3);
        }

        public void CreateArrayInstance()
        {
            double[] dArray1 = (double[])Array.CreateInstance(typeof(double), 3);
            double[,] dArray2 = (double[,])Array.CreateInstance(typeof(double), 3, 4);
            Array arr = Array.CreateInstance(typeof(string), 7);
            arr.SetValue("Monday", 0);
            arr.SetValue("Tuesday", 1);
            arr.SetValue("Wednesday", 2);
            arr.SetValue("Thursday", 3);
            arr.SetValue("Friday", 4);
            arr.SetValue("Saturday", 5);
            arr.SetValue("Sunday", 6);
            StringBuilder sb = new StringBuilder();
            foreach (var s in arr)
            {
                sb.Append(s);
                sb.Append(" ");
            }
            Console.WriteLine(sb.ToString());
        }
    }

}
