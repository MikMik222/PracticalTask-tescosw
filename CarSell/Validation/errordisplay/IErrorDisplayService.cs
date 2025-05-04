namespace CarSell.Service
{
    public interface IErrorDisplayService
    {
        void ShowErrors(IEnumerable<string> errors);
    }
}
