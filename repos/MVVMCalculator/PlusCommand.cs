namespace MVVMCalculator
{
    public class PlusCommand : ICommand
    {
        private Calc receiver;

        public PlusCommand(Calc receiver)
        {
            this.receiver = receiver;
        }

        public double X { get; set; }

        public void Execute ()
        {
            receiver.Plus(X);
        }
    }
}