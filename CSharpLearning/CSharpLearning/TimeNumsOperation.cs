using System;
using System.Globalization;
using System.Net;
using System.Text;

namespace CSharpLearning
{
    public class TimeNumsOperation : IDemonstrate
    {
        public void Demonstrate()
        {
            float ff = 0.2341f;
            Console.WriteLine($"{"p",-15}{ff,-10:p}");
            Console.WriteLine($"{"p3",-15}{ff,-10:p3}");

            Console.WriteLine($"{ 20.5:c}");
            Console.WriteLine($"{ 150.39:c1}");
            Console.WriteLine($"{ 83.71:c0}");
            Console.WriteLine($"{ 122.71125:c4}");

            CultureInfo tw = CultureInfo.GetCultureInfoByIetfLanguageTag("zh-TW");
            CultureInfo us = CultureInfo.GetCultureInfoByIetfLanguageTag("en-US");
            CultureInfo jp = CultureInfo.GetCultureInfoByIetfLanguageTag("ja-JP");

            decimal val = 213.23M;
            Console.WriteLine(val.ToString("C", tw));
            Console.WriteLine(val.ToString("C", us));
            Console.WriteLine(val.ToString("C", jp));

            decimal d = 8582133.76352M;

            Console.WriteLine("{0,-15}{1,-20:G}", "G", d);
            Console.WriteLine("{0,-15}{1,-20:N}", "N", d);

            DateTime dt = new DateTime(2018, 5, 1, 16, 37, 11);
            Console.WriteLine($"long:{dt:D}");
            Console.WriteLine($"short:{dt:d}");

            Console.WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss"));

            Console.WriteLine("-------------------------------");
            double d2 = 1273821730.213721873213d;
            Console.WriteLine($"keep 5:{d2.ToString("0.00000")}");
            Console.WriteLine($"keep 5:{d2.ToString("0.000")}");
            Console.WriteLine($"keep 5:{d2.ToString("0.0")}");
            Console.WriteLine($"keep 5:{d2.ToString("#")}");
            Console.WriteLine("-------------------------------");
            string str2 = "1011101001";
            int result = Convert.ToInt32(str2, 2);
            Console.WriteLine(result);
            Console.WriteLine("-------------------------------");
            string s1 = "4.00012";
            double v1 = double.Parse(s1);
            Console.WriteLine($"s1:{s1},v1:{v1}");
            string s2 = "2018-6-25";
            DateTime v2 = DateTime.Parse(s2);
            Console.WriteLine($"s2:{s2},v2:{v2}");
            string s3 = "6507";
            bool b = short.TryParse(s3, out short v3);
            if (b)
                Console.WriteLine($"s3:{s3},v3:{v3}");
            else
                Console.WriteLine($"s3:{s3}");
            string s4 = "69kh";
            b = int.TryParse(s4, out int v4);
            if (b)
                Console.WriteLine($"s4:{s4},v4:{v4}");
            else
                Console.WriteLine($"s4:{s4}");
            Console.WriteLine("-------------------------------");
            string str3 = "你好，小王";
            byte[] data = Encoding.UTF8.GetBytes(str3);
            Console.WriteLine(BitConverter.ToString(data));
            string str4 = Encoding.UTF8.GetString(data);
            Console.WriteLine(str4);
            Console.WriteLine("-------------------------------");
            string str5 = "<1>Item 1\n<2>Item 2\n<3>Item 3 & Item 4";
            string htmlstr = WebUtility.HtmlEncode(str5);
            Console.WriteLine(str5);
            Console.WriteLine(htmlstr);
        }
    }
}
