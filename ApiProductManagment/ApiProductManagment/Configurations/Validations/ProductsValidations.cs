using FluentValidation;
using ProductManagment.Dto.RequestDto;

namespace ApiProductManagment.Configurations.Validations
{
    public class ProductsValidations : AbstractValidator<ProductsRequestDto>
    {
        public ProductsValidations()
        {
            RuleFor(a => a.NameProduct)
                   .NotEmpty()
                   .WithMessage("The mark field cannot be empty.");

            RuleFor(a => a.ExpirationDate)
                   .NotEmpty()
                   .WithMessage("The expiration date field cannot be empty.");

        }
    }

}
