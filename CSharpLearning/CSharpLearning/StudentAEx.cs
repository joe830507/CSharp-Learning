using System;

namespace CSharpLearning
{
    public class StudentAEx : IDemonstrate
    {
        public void Demonstrate()
        {
            string str = "10026\tJoe\t25\tTaipei";
            StudentA sa = str;
            Console.WriteLine($"ID:{sa.ID},Name:{sa.Name},Age:{sa.Age},City:{sa.City}");
        }
    }
}
