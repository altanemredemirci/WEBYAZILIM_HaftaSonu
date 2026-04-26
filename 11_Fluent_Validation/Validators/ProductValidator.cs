using _11_Fluent_Validation.Models;
using FluentValidation;

namespace _11_Fluent_Validation.Validators
{
    public class ProductValidator:AbstractValidator<Product>
    {
        //FluentValidation paketini kurduk. Fluent Validation modellerin hata durumunda mesajlarını düzenlememizi sağlar.

        public ProductValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("Ürün Adı boş geçilemez.");

            RuleFor(p => p.Name).MaximumLength(40).WithMessage("Ürün Adı 40 karakterden uzun olamaz.");

            RuleFor(p => p.Name).MinimumLength(3).WithMessage("Ürün Adı 3 karakterden kısa olamaz.");

            RuleFor(p => p.Name).Length(3, 40).WithMessage("Ürün Adı 3 ile 40 karakter arasında olmalıdır.");


            RuleFor(p => p.Price).NotEmpty().WithMessage("Ürün Fiyatı boş geçilemez");
            
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("Ürün Fiyatı 0'dan büyük olmalıdır.");

            RuleFor(p => p.Price).LessThan(1000).WithMessage("Ürün Fiyatı 1000'dan küçük olmalıdır.");


            RuleFor(p => p.Stock).NotEmpty().WithMessage("Ürün Stok boş geçilemez");

            RuleFor(p => p.Stock).GreaterThan(0).WithMessage("Ürün Stok 0'dan büyük olmalıdır.");

            RuleFor(p => p.Stock).LessThan(1000).WithMessage("Ürün Stok 1000'dan küçük olmalıdır.");
        }
    }
}
