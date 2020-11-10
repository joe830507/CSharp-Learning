namespace CSharpLearning
{
    public class Order
    {
        public int OID { get; set; }
        public string CustomName { get; set; }
        public string ContactName { get; set; }
        public float Amount { get; set; }
        public string PhoneNo { get; set; }

        public void Deconstruct(out int oid, out string custName, out string contact, out float amount, out string phone)
        {
            oid = OID;
            custName = CustomName;
            contact = ContactName;
            amount = Amount;
            phone = PhoneNo;
        }
    }
}
