namespace SingletonDemo
{
    public sealed class Singleton
    {
        private static Singleton instance;

        //pro vylouceni konkutentniho pristupu v inicializaci instance
        private static object synchLock = new object();

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (synchLock)
                    {
                        if (instance == null)
                            instance = new Singleton();
                    }
                }
                return instance;
            }
        }

        private Singleton() {}

        public void DoStuff() { System.Console.WriteLine("xxx"); }
    }
}
