using System;

namespace CSharpLearning
{
    public class AOrder
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public bool State { get; set; }
        public OrderDetails Details { get; set; }
    }
}
