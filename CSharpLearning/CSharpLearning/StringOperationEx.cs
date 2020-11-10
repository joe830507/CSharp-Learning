using System;
using System.Text;

namespace CSharpLearning
{
    public class StringOperationEx : IDemonstrate
    {
        public void Demonstrate()
        {
            string a = "abc", b = "efg", c = "hij";
            Console.WriteLine(string.Concat(a, b, c));
            Console.WriteLine("I need your support.".Contains("need"));
            Console.WriteLine("I need your support.".ToUpper());
            Console.WriteLine("I need your support.".ToLower());
            string[] strs = { a, b, c };
            Console.WriteLine(string.Join("-", strs));
            Console.WriteLine(c.EndsWith("ij"));

            string[] splitStrs = "enlarge*a*picture".Split("*");
            foreach (var s in splitStrs)
            {
                Console.WriteLine(s);
            }

            string replacedStr = "This is the awesome year.".Replace("awesome", "terrible");
            Console.WriteLine(replacedStr);

            string reversedStr = "abcdefghijklmnopqr";
            char[] charr = reversedStr.ToCharArray();
            Array.Reverse(charr);
            Console.WriteLine(new string(charr));

            Console.WriteLine("I need your support.".Insert(1, " really"));
            Console.WriteLine("I need your support.".Remove(2, 4));

            Console.WriteLine("abcdef".PadLeft(20, '*'));
            Console.WriteLine("abcdef".PadRight(20, '+'));

            char[] charrr = { '3', 'a', '#', '%' };
            foreach (var ch in charrr)
            {
                Console.WriteLine(char.IsNumber(ch));
            }

            Console.WriteLine("I need your support.".Substring(2, 10));

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Happy !")
            .Append("abc")
            .Append("-")
            .Append("xyz\n")
            .AppendFormat($"0x{144650:x} = {144650}\n")
            .AppendJoin('~', 50, false, 3.6625d)
            .AppendLine()
            .Replace("Happy", "Hello Jim");
            Console.WriteLine(sb);

            string strr = "yo yo yyyyooo yo";
            Console.WriteLine(strr.IndexOf("yo"));
            Console.WriteLine(strr.LastIndexOf("yo"));

            int rc = string.Compare("abcd", "ABCD", true);
            Console.WriteLine(rc);
            int rcc = string.Compare("abcd", "ABCD", false);
            Console.WriteLine(rcc);

            string specialLiteral1 = @"\folder1\folder2\test.txt";
            string specialLiteral2 = "\\folder1\\folder2\\test.txt";
            Console.WriteLine(specialLiteral1);
            Console.WriteLine(specialLiteral2);

            string s2 = @"execute the ""donet new"" command";
            Console.WriteLine(s2);
        }
    }
}
