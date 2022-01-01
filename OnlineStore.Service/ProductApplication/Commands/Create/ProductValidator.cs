using FluentValidation;
using OnlineStore.Application.ProductApplication.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.ProductApplication.Commands.Create
{
    public class ProductCreateCommandValidator : AbstractValidator<ProductCreateCommand>
    {
        public ProductCreateCommandValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage("Required");
            RuleFor(u => u.Price).GreaterThan(0).WithMessage("Food can not be free!");
        }
    }
}
