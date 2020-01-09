using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace FilterAndPipes
{
    public class Pipe
    {
        public Pipe()
        {
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
