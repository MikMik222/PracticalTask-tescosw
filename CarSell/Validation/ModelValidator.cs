
using CarSell.Service;
using System.ComponentModel.DataAnnotations;


namespace CarSell.Validation
{
    public class ModelValidator : IModelValidator
    {
        private readonly IErrorDisplayService _errorDisplayService;

        public ModelValidator(IErrorDisplayService errorDisplayService)
        {
            _errorDisplayService = errorDisplayService;
        }

        public List<string> Validate(object model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, serviceProvider: null, items: null);

            bool isValid = Validator.TryValidateObject(model, validationContext, validationResults, true);
            var errorMessages = new List<string>();

            if (!isValid)
            {
                foreach (var validationResult in validationResults)
                {
                    errorMessages.Add(validationResult.ErrorMessage);
                }

                _errorDisplayService.ShowErrors(errorMessages);
            }

            return errorMessages;
        }
    }
}
