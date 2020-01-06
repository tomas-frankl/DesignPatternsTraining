namespace AbstractFactory
{
    class Client
    {
        IShapeFactory factory;

        public Client(IShapeFactory factory)
        {
            this.factory = factory;
        }

        public void Use()
        {
            var circle = factory.CreateCircle();
            circle.UseCircle();

            var square = factory.CreateSquare();
            square.UseSquare();
        }
    }
}
