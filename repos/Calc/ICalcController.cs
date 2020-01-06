namespace Calc
{
    public interface ICalcController
    {
        void PlusAction(string x);
        
        ICalcView CalcView { get; set; }
    }
}