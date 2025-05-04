namespace CarSell.Service
{
    public class DateFormatService
        : IDateFormatService
    {
        private const string format = "dd.MM.yyyy";


        public string Format(DateTime dateTime)
        {
            return dateTime.ToString(format);
        }
    }
}
