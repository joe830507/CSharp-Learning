using System.Xml.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example235 : IDemonstration
    {
        XNamespace ns1 = "demo1.org";
        XNamespace ns2 = "demo2.org";
        public void display()
        {
            XAttribute profileAtt1 = new XAttribute(XNamespace.Xmlns + "na", ns1);
            XAttribute profileAtt2 = new XAttribute(XNamespace.Xmlns + "nb", ns2);
            XElement xml = new XElement(ns1 + "Root", profileAtt1, profileAtt2,
                new XElement(ns1 + "Layout1", "Border"),
                new XElement(ns1 + "Layout2", "Canvas"));
            System.Console.WriteLine(xml);
        }
    }
}
