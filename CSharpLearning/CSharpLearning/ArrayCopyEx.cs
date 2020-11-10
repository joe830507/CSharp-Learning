using System;

namespace CSharpLearning
{
    public class ArrayCopyEx : IDemonstrate
    {
        public void Demonstrate()
        {
            int[] arr1 = { 1, 2, 3, 4, 5, 6 };
            int[] arr2 = new int[3];
            // from arr1[3] to arr1[5] copy to arr2
            // start from arr2[0], there are three elements copied 
            // arr1[3] -> arr2[0]
            // arr1[4] -> arr2[1]
            // arr1[5] -> arr2[2]
            Array.Copy(arr1, 3, arr2, 0, 3);
            foreach (var num in arr2)
            {
                Console.WriteLine(num);
            }
        }
    }
}
