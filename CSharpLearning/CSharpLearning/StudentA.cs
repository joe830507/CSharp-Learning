using System;

namespace CSharpLearning
{
    public class StudentA
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }

        public static implicit operator StudentA(string str)
        {
            string[] strArr = str.Split("\t");
            if (strArr.Length != 4)
                return null;
            return new StudentA
            {
                ID = Convert.ToInt32(strArr[0]),
                Name = strArr[1],
                Age = Convert.ToInt32(strArr[2]),
                City = strArr[3]
            };
        }
    }
}
