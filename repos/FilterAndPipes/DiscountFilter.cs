namespace FilterAndPipes
{
    public class DiscountFilter : FilterBase
    {
        protected override Order Transform(Order order)
        {
            if (order.Price > 1000000)
            {
                order.Price *= 0.9;
            }
            return order;
        }
    }
}