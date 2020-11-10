namespace CSharpLearning
{
    class Product
    {
        public string Name { get; set; }
        public int Code { get; set; }

        public static void Update(ref Product p)
        {
            p = new Product
            {
                Name = "test1",
                Code = 9999
            };
        }
    }
}
