using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_LINQ_DynamicType
{
    public class Example227 : IDemonstration
    {
        public void display()
        {
            OrderDetails d1 = new OrderDetails
            {
                Amount = 10,
                Price = 2.5M,
                Code = "T-70770"
            };
            OrderDetails d2 = new OrderDetails
            {
                Amount = 12,
                Price = 3.2M,
                Code = "T-70778"
            };
            Order o1 = new Order
            {
                ID = 1,
                Date = new DateTime(2018, 3, 1),
                State = true,
                Details = d1
            };
            Order o2 = new Order
            {
                ID = 2,
                Date = new DateTime(2018, 3, 13),
                State = false,
                Details = d2
            };
            Order o3 = new Order
            {
                ID = 3,
                Date = new DateTime(2018, 3, 18),
                State = true,
                Details = null
            };
            List<Order> orders = new List<Order> { o1, o2, o3 };
            List<OrderDetails> details = new List<OrderDetails> { d1, d2 };
            var q = from o in orders
                    join d in details on o.Details equals d into g
                    from x in g.DefaultIfEmpty(new OrderDetails { Amount = 0, Price = 0.00M, Code = "Unknown Code" })
                    select (OrderID: o.ID, Amount: x.Amount, Code: x.Code);
            foreach (var i in q)
            {
                Console.WriteLine("{0,-11}{1,-10}{2,-20}", i.OrderID, i.Amount, i.Code);
            }
        }

        public class OrderDetails
        {
            public int Amount { get; set; }
            public decimal Price { get; set; }
            public string Code { get; set; }
        }

        public class Order
        {
            public int ID { get; set; }
            public DateTime Date { get; set; }
            public bool State { get; set; }
            public OrderDetails Details { get; set; }
        }
    }
}
