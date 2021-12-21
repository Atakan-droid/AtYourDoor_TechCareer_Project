using AuthManager.Entities.DTOs;
using Business.Utilities.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class UserLoginDTOValidator: AbstractValidator<UserLoginDTO>
    {
        public UserLoginDTOValidator()
        {
            RuleFor(u => u.Mail).EmailAddress();
       
            RuleFor(p => p.Password).NotEmpty().WithMessage(Messages.UserPasswordNotEmpty)
                    .MinimumLength(8).WithMessage(Messages.UserPasswordMin8)
                    .Matches(@"[A-Z]+").WithMessage(Messages.UserPasswordAtLeastUpper)
                    .Matches(@"[a-z]+").WithMessage(Messages.UserPasswordAtLeastLower)
                    .Matches(@"[0-9]+").WithMessage(Messages.UserPasswordAtLeastNumber);
        }
    }
}
