using FluentValidation;
using InstantPOS.Application.CQRS.ProductType.Command;

namespace InstantPOS.Application.Validator
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
