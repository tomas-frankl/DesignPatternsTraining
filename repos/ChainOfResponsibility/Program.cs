using System;

namespace ChainOfResponsibility
{
    class Program
    {
        abstract class Handler
        {
            public Handler Next { get; set; }

            protected abstract bool IsForMe(Order order);
            protected abstract Order DoHandle(Order order);

            public Order Handle(Order order)
            {
                if (IsForMe(order))
                    return DoHandle(order);
                else
                    return Next.Handle(order);
            }

        }

        class PartnerDiscount : Handler
        {
            protected override Order DoHandle(Order order)
            {
                order.Price *= 0.9;
                return order;
            }

            protected override bool IsForMe(Order order)
            {
                return order.Customer == "gopas";
            }
        }

        class VolumeDiscount : Handler
        {
            protected override Order DoHandle(Order order)
            {
                order.Price -= 1000;
                return order;
            }

            protected override bool IsForMe(Order order)
            {
                return order.Price >= 1000000;
            }
        }

        class NoDiscount : Handler
        {
            protected override Order DoHandle(Order order)
            {
                return order;
            }

            protected override bool IsForMe(Order order)
            {
                return true;
            }
        }

        static void Main(string[] args)
        {
            var pd = new PartnerDiscount();
            pd.Next = new VolumeDiscount();
            pd.Next.Next = new NoDiscount();

            var o1 = new Order() { Customer = "gopas", Price = 2000000, Text = "slon" };
            var o2 = new Order() { Customer = "tieto", Price = 2000000, Text = "slon" };
            var o3 = new Order() { Customer = "xxx", Price = 1500, Text = "krecek" };

            pd.Handle(o1);
            pd.Handle(o2);
            pd.Handle(o3);

            Console.WriteLine($"{o1.Customer}, {o1.Text}, {o1.Price}");
            Console.WriteLine($"{o2.Customer}, {o2.Text}, {o2.Price}");
            Console.WriteLine($"{o3.Customer}, {o3.Text}, {o3.Price}");
        }
    }
}
