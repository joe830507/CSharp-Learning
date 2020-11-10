using System.Collections.Generic;

namespace CSharpLearning
{
    public class ComparerEx : IDemonstrate
    {
        public void Demonstrate()
        {
            HashSet<Contact> sets = new HashSet<Contact>(new ContactEqualityComparer());
            sets.Add(new Contact
            {
                ID = 72001,
                Name = "Mr.Li",
                PhoneNo = "0800092000"
            });
            Contact c1 = new Contact
            {
                ID = 7300111,
                Name = "Mr.Chang",
                PhoneNo = "0721092000"
            };
            Contact c2 = c1;
            sets.Add(c1);
            sets.Add(c2);
            Contact c3 = new Contact
            {
                ID = 500002,
                Name = "Mr.Lu",
                PhoneNo = "54492456s"
            };
            Contact c4 = new Contact
            {
                ID = 500002,
                Name = "Mr.Lu",
                PhoneNo = "54492456s"
            };
            sets.Add(c3);
            sets.Add(c4);
            foreach (var c in sets)
            {
                System.Console.WriteLine("ID:{0},Name:{1},Phone:{2}", c.ID, c.Name, c.PhoneNo);
            }
        }
    }
}
