using E_CommerceProduct.Application.Orders.Request;
using FluentValidation;

namespace E_CommerceProductAPI.Infrastructure.Validators
{
    public class CreateOrderRequestModelValidator : AbstractValidator<CreateOrderRequestModel>
    {
        public CreateOrderRequestModelValidator()
        {
            RuleFor(x => x.OrderItems)
                .NotNull()
                .NotEmpty().WithMessage("OrderItems must not be empty.")
                .ForEach(orderItem => orderItem.SetValidator(new OrderProductRequestModelValidator()));
        }
    }
}
