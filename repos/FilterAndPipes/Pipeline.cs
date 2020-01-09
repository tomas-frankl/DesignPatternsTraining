using System.Collections.Generic;

namespace FilterAndPipes
{
    public class Pipeline
    {
        List<FilterBase> filters = new List<FilterBase>();

        public Pipe InPipe { get; private set; }
        public Pipe OutPipe { get; private set; }
        
        public Pipeline()
        {
            InPipe = OutPipe = new Pipe();
        }
        
        public void AddFilter<T>(int count)
            where T : FilterBase, new()
        {
            var nextPipe = new Pipe();

            for (int i = 0; i < count; i++)
            {
                var filter = new T() { InPipe = OutPipe, OutPipe = nextPipe};
                filters.Add(filter);
            }

            OutPipe = nextPipe;
        }
    }
}
