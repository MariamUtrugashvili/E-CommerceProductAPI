using E_CommerceProduct.Application.ProductCategories.Request;
using FluentValidation;

namespace E_CommerceProductAPI.Infrastructure.Validators
{
    public class ProductCategoriesRequestModelValidator : AbstractValidator<ProductCategoriesRequestModel>
    {
        public ProductCategoriesRequestModelValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId must not be empty.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("CategoryId must not be empty.");
        }
    }
}
