namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory1 = new BlueFactory();
            var client1 = new Client(factory1);
            client1.Use();

            var factory2 = new RedFactory();
            var client2 = new Client(factory2);
            client2.Use();
        }
    }
}
