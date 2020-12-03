using System.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example229 : IDemonstration
    {
        string[] arrsrc =
        {
            "at","act","market","fable","also","alt","bee","back","book",
            "build","face","full","fish","food","find","meet","make","moo",
            "muklek"
        };
        public void display()
        {
            var q = from s in arrsrc
                    group s by s[0].ToString().ToUpper() into g
                    orderby g.Key
                    let nq = (
                        from w in g
                        orderby w
                        select w
                    )
                    select (Key: g.Key, Items: nq);
            foreach (var t in q)
            {
                System.Console.WriteLine(t.Key);
                foreach (var sub in t.Items)
                {
                    System.Console.WriteLine("  {0}", sub);
                }
            }
        }
    }
}
