using E_CommerceProduct.Application.Orders.Request;
using FluentValidation;

namespace E_CommerceProductAPI.Infrastructure.Validators
{
    public class OrderProductRequestModelValidator : AbstractValidator<OrderProductRequestModel>
    {
        public OrderProductRequestModelValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("ProductName must not be empty.")
                .MinimumLength(2).WithMessage("ProductName must be at least 2 characters long.")
                .MaximumLength(100).WithMessage("ProductName must be less than 100 characters.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }
    }
}
