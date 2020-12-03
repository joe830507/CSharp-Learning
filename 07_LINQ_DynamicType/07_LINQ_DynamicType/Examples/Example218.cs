using System.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example218 : IDemonstration
    {
        Contact[] contacts =
        {
            new Contact
            {
                ContactID = 6501,
                ContactName = "A",
                ContactEmail = "A@gmail.com",
                ContactPhoneNo = "123456789748"
            },
            new Contact
            {
                ContactID = 6502,
                ContactName = "B",
                ContactEmail = "B@gmail.com",
                ContactPhoneNo = "1234567892131"
            },
            new Contact
            {
                ContactID = 6503,
                ContactName = "C",
                ContactEmail = "C@gmail.com",
                ContactPhoneNo = "5454654564548"
            },
            new Contact
            {
                ContactID = 6504,
                ContactName = "D",
                ContactEmail = "D@gmail.com",
                ContactPhoneNo = "54435189748"
            },
            new Contact
            {
                ContactID = 6505,
                ContactName = "E",
                ContactEmail = "E@gmail.com",
                ContactPhoneNo = "849564892131"
            },
            new Contact
            {
                ContactID = 6506,
                ContactName = "F",
                ContactEmail = "F@gmail.com",
                ContactPhoneNo = "465124564548"
            },
        };
        public void display()
        {
            var result = contacts.Where(c => c.ContactPhoneNo.StartsWith("123") ||
                                             c.ContactPhoneNo.StartsWith("54"));
            foreach (var ct in result)
            {
                System.Console.WriteLine($"ContactID:{ct.ContactID}");
                System.Console.WriteLine($"ContactName:{ct.ContactName}");
                System.Console.WriteLine($"ContactEmail:{ct.ContactEmail}");
                System.Console.WriteLine($"ContactPhoneNo:{ct.ContactPhoneNo}");
                System.Console.WriteLine();
            }
        }

        public class Contact
        {
            public int ContactID { get; set; }
            public string ContactName { get; set; }
            public string ContactEmail { get; set; }
            public string ContactPhoneNo { get; set; }
        }
    }
}
