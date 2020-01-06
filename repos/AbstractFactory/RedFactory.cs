namespace AbstractFactory
{
    class RedFactory : IShapeFactory
    {
        public ISquare CreateSquare() => new RedSquare();

        public ICircle CreateCircle() => new RedCircle();
    }
}
