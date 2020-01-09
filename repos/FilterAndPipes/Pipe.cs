using System.Collections.Concurrent;

namespace FilterAndPipes
{
    public class Pipe
    {
        public string Name { get; }
        public Pipe(string name)
        {
            Name = name;
        }

        ConcurrentQueue<Order> queue = new ConcurrentQueue<Order>();

        public bool HasMessage => !queue.IsEmpty;

        public Order Get()
        {
            if (queue.TryDequeue(out Order order))
                return order;
            else
                throw new System.Exception("Can't dequeue");
        }

        public void Put(Order order)
        {
            queue.Enqueue(order);
        }
    }
}
