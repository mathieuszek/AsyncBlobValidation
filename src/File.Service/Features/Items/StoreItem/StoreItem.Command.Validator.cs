using FluentValidation;

namespace File.Service.Features.Items.StoreItem;

/// <summary>
/// Validates <see cref="StoreItemCommand"/>.
/// </summary>
public sealed class StoreItemCommandValidator : AbstractValidator<StoreItemCommand>
{
    public StoreItemCommandValidator()
    {
        RuleFor(message => message.Description)
            .NotNull()
            .NotEmpty()
            .MaximumLength(200);
    }
}