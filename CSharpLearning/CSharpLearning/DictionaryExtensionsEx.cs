using System.Collections.Generic;

namespace CSharpLearning
{
    public class DictionaryExtensionsEx : IDemonstrate
    {
        public void Demonstrate()
        {
            System.Console.WriteLine("Nothing");
        }

        static IReadOnlyDictionary<string, string> GetReadOnly()
        {
            IDictionary<string, string> d = new Dictionary<string, string>();
            d["city"] = "Guang Zhou";
            d["name"] = "Mr Liu";
            d["subject"] = "ASP.NET Core";
            return d.ToReadOnlyDictionary();
        }

        public static void StaticDemonstrate()
        {
            IReadOnlyDictionary<string, string> rdic = GetReadOnly();
            foreach (string key in rdic.Keys)
            {
                System.Console.WriteLine("{0} - {1}", key, rdic[key]);
            }
        }
    }

}
