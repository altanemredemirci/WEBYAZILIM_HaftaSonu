using _11_Fluent_Validation.Models;
using FluentValidation;

namespace _11_Fluent_Validation.Validators
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Boş Geçilemez");
            RuleFor(c => c.Name).Length(3,50).WithMessage("Min 3 Max 50 karakter girilmelidir.");

            RuleFor(c => c.Description).NotEmpty().WithMessage("Boş Geçilemez");
            RuleFor(c => c.Description).Length(3, 50).WithMessage("Min 3 Max 50 karakter girilmelidir.");
        }
    }
}
