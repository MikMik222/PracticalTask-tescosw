namespace CarSell.Validation
{
    public interface IModelValidator
    {
        List<string> Validate(object model);
    }
}
