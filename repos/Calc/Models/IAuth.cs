namespace Calc.Models
{
    public interface IAuth
    {
        bool Login(string userName, string password);
    }
}