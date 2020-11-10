using System;

namespace CSharpLearning
{
    class PredicateExample
    {
        static int[] arr = { 16,21,20,11,18,37,41,77};
        static int[] resarr;
        public delegate bool Predicate<in T>(T obj);


        public static void Demonstrate()
        {
            resarr = Array.FindAll(arr, element =>
            {
                if (element % 2 == 0 || element % 3 == 0)
                    return true;
                return false;
            });
            if(resarr.Length>0)
                foreach (var num in resarr)
                {
                    Console.WriteLine(num);
                }
        }
    }
}
