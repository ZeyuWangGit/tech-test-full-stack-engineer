using FluentValidation;

namespace Hipages.Tradies.Application.Features.Jobs.Commands.UpdateJob;

public class UpdateJobCommandValidator : AbstractValidator<UpdateJobCommand>
{
    public UpdateJobCommandValidator()
    {
        RuleFor(p => p.Status)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();

        RuleFor(p => p.SuburbName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters.");

        RuleFor(p => p.Postcode)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(4).WithMessage("{PropertyName} must not exceed 4 characters.");

        RuleFor(p => p.CategoryName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters.");

        RuleFor(p => p.ContactName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters.");

        RuleFor(p => p.ContactEmail)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters.");

        RuleFor(p => p.ContactPhone)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters.");

        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThan(0);

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("{PropertyName} is required.");

    }
}