using System.Linq;
using System.Xml.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example231 : IDemonstration
    {
        XElement testel = new XElement("Productions",
                new XElement("Product",
                    new XElement("id", 1201),
                    new XElement("desc", "Product A"),
                    new XElement("mode", 7)
                ),
                new XElement("Product",
                    new XElement("id", 1202),
                    new XElement("desc", "Product B"),
                    new XElement("mode", 3)
                )
            );
        public void display()
        {
            var q = from x in testel.Elements()
                    where (int)x.Element("mode") == 3
                    select x;
            if (q.Count() > 0)
            {
                XElement e = q.First();
                e.Element("desc").Value = "Product G";
            }
            System.Console.WriteLine(testel);
        }
    }
}
