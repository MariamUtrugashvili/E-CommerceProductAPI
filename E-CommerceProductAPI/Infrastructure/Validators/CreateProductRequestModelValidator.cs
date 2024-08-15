using E_CommerceProduct.Application.Products.Request;
using FluentValidation;

namespace E_CommerceProductAPI.Infrastructure.Validators
{
    public class CreateProductRequestModelValidator : AbstractValidator<CreateProductRequestModel>
    {
        public CreateProductRequestModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name must not be empty.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters long.")
                .MaximumLength(100).WithMessage("Name must be less than 100 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("ImageUrl must not be empty.")
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute)).WithMessage("ImageUrl must be a valid URL.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

            RuleFor(x => x.CategoryNames)
                .NotNull().WithMessage("CategoryNames must not be null.")
                .NotEmpty().WithMessage("CategoryNames must not be empty.");
        }
    }

}
