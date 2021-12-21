using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class OrderAddDTOValidator: AbstractValidator<OrderAddDTO>
    {
        public OrderAddDTOValidator()
        {
            RuleFor(o => o.Products).NotEmpty();
            RuleFor(o => o.UserId).NotEmpty();
            RuleFor(o => o.AddressId).NotEmpty();
        }
    }
}
