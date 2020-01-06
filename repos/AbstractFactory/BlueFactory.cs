namespace AbstractFactory
{
    class BlueFactory : IShapeFactory
    {
        public ISquare CreateSquare() => new BlueSquare();

        public ICircle CreateCircle() => new BlueCircle();
    }
}
