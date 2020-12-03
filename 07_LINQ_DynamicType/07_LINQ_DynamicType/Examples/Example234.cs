using System.Xml.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example234 : IDemonstration
    {
        XNamespace ns = "http://demo.org";
        public void display()
        {
            XElement n1 = new XElement(ns + "Group",
                            new XElement(ns + "Name", "Jack"),
                            new XElement(ns + "Level", 3));
            XElement n2 = new XElement(ns + "Group",
                            new XElement(ns + "Name", "Tom"),
                            new XElement(ns + "Level", 2));
            XElement n3 = new XElement(ns + "Group",
                            new XElement(ns + "Name", "Jim"),
                            new XElement(ns + "Level", 7));
            XElement root = new XElement(ns + "Groups", n1, n2, n3);
            System.Console.WriteLine(root);
        }
    }
}
