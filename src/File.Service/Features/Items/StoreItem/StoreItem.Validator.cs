using FluentValidation;

namespace File.Service.Features.Items.StoreItem;

/// <summary>
/// Validates <see cref="StoreItemMessage"/>.
/// </summary>
public sealed class StoreItemMessageValidator : AbstractValidator<StoreItemMessage>
{
    public StoreItemMessageValidator()
    {
        RuleFor(message => message.Description)
            .NotNull()
            .NotEmpty()
            .MaximumLength(200);
    }
}