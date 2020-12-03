using System;
using System.Linq;
using System.Xml.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example233 : IDemonstration
    {
        XElement xml = new XElement("Items",
                new XElement("Item",
                    new XAttribute("Val1", 100),
                    new XAttribute("Val2", 250)),
                new XElement("Item",
                    new XAttribute("Val1", 7500),
                    new XAttribute("Val2", 900)),
                new XElement("Item",
                    new XAttribute("Val1", 2003),
                    new XAttribute("Val2", 6230))
            );
        public void display()
        {
            var q = from el in xml.Elements("Item")
                    let v1 = Convert.ToInt32(el.Attribute("Val1").Value)
                    let v2 = Convert.ToInt32(el.Attribute("Val2").Value)
                    select (Value_1: v1, Value_2: v2);
            foreach (var t in q)
            {
                Console.WriteLine($"Value 1 : {t.Value_1}\nValue 2 : {t.Value_2}\n");
            }
        }
    }
}
