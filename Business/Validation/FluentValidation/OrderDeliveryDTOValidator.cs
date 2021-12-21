using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class OrderDeliveryDTOValidator: AbstractValidator<OrderDeliveryDTO>
    {
        public OrderDeliveryDTOValidator()
        {
            RuleFor(o => o.IsDelivered).NotNull();
            RuleFor(o => o.OrderId).NotEmpty();
            RuleFor(o => o.Note).NotEmpty();
        }
    }
}
