using FluentValidation;
using ProductManagment.Dto.RequestDto;

namespace ApiProductManagment.Configurations.Validations
{
    public class MarkValidations : AbstractValidator<MarkRequestDto>
    {
        public MarkValidations()
        {
            RuleFor(a => a.Mark)
                   .NotEmpty()
                   .WithMessage("The mark field cannot be empty.")
                   .MaximumLength(100);
                  
        }
    }
}
