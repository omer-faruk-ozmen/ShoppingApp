using FluentValidation;
using ShoppingApp.Application.ViewModels.Products;

namespace ShoppingApp.Application.Validators.Products
{
    public class CreateProductValidator:AbstractValidator<CreateProductViewModel>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Name is required")
                .MaximumLength(150)
                .MinimumLength(3)
                    .WithMessage("Name must be between 3 and 150 characters");
            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Number of stocks required")
                .Must(s => s >= 0)
                    .WithMessage("Please enter a valid stock value");
            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Price is required")
                .Must(p=>p>=0)
                    .WithMessage("Please enter a valid price value");
        }
    }
}
