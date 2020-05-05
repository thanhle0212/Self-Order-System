using FluentValidation;

namespace InstantPOS.Application.CQRS.ProductType.Command
{
    public class CreateProductTypeCommandValidator : AbstractValidator<CreateProductTypeCommand>
    {
        public CreateProductTypeCommandValidator()
        {
            RuleFor(v => v.ProductTypeName)
                .MaximumLength(250)
                .NotEmpty();

            RuleFor(v => v.ProductTypeKey)
               .MaximumLength(50)
               .NotEmpty();
        }
    }
}
