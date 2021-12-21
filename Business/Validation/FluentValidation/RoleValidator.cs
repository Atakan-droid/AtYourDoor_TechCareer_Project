using AuthManager.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class RoleValidator: AbstractValidator<Roles>
    {
        public RoleValidator()
        {
            RuleFor(r => r.Role).NotEmpty();
        }
    }
}
