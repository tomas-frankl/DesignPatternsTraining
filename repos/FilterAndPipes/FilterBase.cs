using System;
using System.Timers;

namespace FilterAndPipes
{
    abstract public class FilterBase
    {
        public Pipe InPipe { get; set; }
        public Pipe OutPipe { get; set; }

        Timer timer = new Timer(1000);

        public FilterBase()
        {
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (InPipe != null && InPipe.HasMessage)
            {
                var inOrder = InPipe.Get();

                var outOrder = Transform(inOrder);

                if (outOrder != null && OutPipe != null)
                    OutPipe.Put(outOrder);
            }
        }

        protected abstract Order Transform(Order order);
    }
}