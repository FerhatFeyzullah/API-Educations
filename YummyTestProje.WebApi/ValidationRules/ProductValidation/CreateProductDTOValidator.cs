using FluentValidation;
using YummyTestProje.WebApi.DTO.ProductDTO;

namespace YummyTestProje.WebApi.ValidationRules.ProductValidation
{
    public class CreateProductDTOValidator :AbstractValidator<CreateProductDTO>
    {
        public CreateProductDTOValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Urun Adini Bos Gecmeyin")
                .MinimumLength(2).WithMessage("Urun Adi En Az 2 Karakter olmali")
                .MaximumLength(20).WithMessage("Urun adi maksimum 20 karakter olmali");
            RuleFor(x => x.ProductDescription)
                .NotEmpty().WithMessage("Urun Aciklamasini Bos Gecmeyin")
                .MinimumLength(2).WithMessage("Urun Aciklamasi En Az 2 Karakter olmali")
                .MaximumLength(100).WithMessage("Urun Aciklamasi maksimum 100 karakter olmali");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Fiyati Bos Gecmeyin")
                .GreaterThan(0).WithMessage("Fiyat 0'dan Buyuk Olmalidir")
                .LessThan(1000).WithMessage("Fiyat 1000'dan Kucuk Olmalidir");
        }
    }
}
