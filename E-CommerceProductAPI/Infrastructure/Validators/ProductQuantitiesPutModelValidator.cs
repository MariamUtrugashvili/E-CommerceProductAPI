using E_CommerceProduct.Application.ProductQuantities.Request;
using FluentValidation;

namespace E_CommerceProductAPI.Infrastructure.Validators
{
    public class ProductQuantitiesPutModelValidator : AbstractValidator<ProductQuantitiesPutModel>
    {
        public ProductQuantitiesPutModelValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId must not be empty.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }
    }
}
