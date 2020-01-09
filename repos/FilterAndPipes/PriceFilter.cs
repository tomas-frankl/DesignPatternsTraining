namespace FilterAndPipes
{
    public class PriceFilter : FilterBase
    {
        protected override Order Transform(Order order)
        {
            if (order.Price > 10000)
                return order;
            return null;
        }
    }
}