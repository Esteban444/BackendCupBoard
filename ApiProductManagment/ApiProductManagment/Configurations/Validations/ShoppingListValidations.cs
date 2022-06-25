using FluentValidation;
using ProductManagment.Dto.RequestDto;

namespace ApiProductManagment.Configurations.Validations
{
    public class ShoppingListValidations : AbstractValidator<ShoppingListRequestDto>
    {
        public ShoppingListValidations()
        {
            RuleFor(a => a.Amount)
                   .NotEmpty()
                   .WithMessage("The amound field cannot be empty.");
            RuleFor(a => a.Value)
             .NotEmpty()
             .WithMessage("The value field cannot be empty.");
        }
    }
}
