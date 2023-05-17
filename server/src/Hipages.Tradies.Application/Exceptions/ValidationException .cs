
using FluentValidation.Results;

namespace Hipages.Tradies.Application.Exceptions;

public class ValidationException : ApplicationException
{
    public List<string> ValidationErrors { get; set; }

    public ValidationException(ValidationResult validationResult)
    {
        this.ValidationErrors = new List<string>();

        foreach (var validationError in validationResult.Errors)
        {
            this.ValidationErrors.Add(validationError.ErrorMessage);
        }
    }
}