using System.Linq;
using System.Xml.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example228 : IDemonstration
    {
        Account[] accs =
        {
            new Account
            {
                UserID = 1,
                UserName = "user 1",
                Password = "123",
                IsAdmin = false
            },
            new Account
            {
                UserID = 2,
                UserName = "user 2",
                Password = "678",
                IsAdmin = false
            },
            new Account
            {
                UserID = 3,
                UserName = "user 3",
                Password = "hjk",
                IsAdmin = true
            },
        };
        public void display()
        {
            var elements = from a in accs
                           select new XElement("account",
                               new XAttribute("user_id", a.UserID),
                               new XAttribute("user_name", a.UserName),
                               new XAttribute("password", a.Password),
                               new XAttribute("is_admin", a.IsAdmin)
                           );
            XElement root = new XElement("accounts", elements);
            XDocument doc = new XDocument(root);
            System.Console.WriteLine(doc);
        }

        public class Account
        {
            public int UserID { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public bool IsAdmin { get; set; }
        }
    }
}
