using System;

namespace CSharpLearning
{
    public class OrderData
    {
        [MyDemo(Description = "Order Id")]
        public int OrderId { get; set; }
        [MyDemo(Description = "Add Time")]
        public DateTime AddTime { get; set; }
        [MyDemo(Description = "Discount")]
        public double Compute(double d)
        {
            return d * 0.98;
        }
    }
}
