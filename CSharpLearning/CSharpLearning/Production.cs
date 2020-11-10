using System;

namespace CSharpLearning
{
    class Production
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime ProductDate { get; set; }
        public Production(Guid pid, string pname,DateTime pdate)
        {
            ProductId = pid;
            ProductName = pname;
            ProductDate = pdate;
        }

        public Production(string pname, DateTime pdate) : this(Guid.NewGuid(), pname, pdate) { }
        public Production() : this(Guid.NewGuid(), "Unknown Product", DateTime.Today) { }

    }
}
