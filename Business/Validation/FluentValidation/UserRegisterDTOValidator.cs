using AuthManager.Entities;
using AuthManager.Entities.DTOs;
using Business.Utilities.Messages;
using Data.Concrete.EntityFramework.Context;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class UserRegisterDTOValidator: AbstractValidator<UserRegisterDTO>
    {
        public UserRegisterDTOValidator()
        {
            RuleFor(u => u.Mail).EmailAddress().Must(UniqueMail).WithMessage(Messages.UserMailMustUnique);
            RuleFor(u => u.Name).NotEmpty();
            RuleFor(u => u.Surname).NotEmpty();
            RuleFor(u => u.PhoneNumber).NotEmpty().Length(11);
            RuleFor(p => p.Password).NotEmpty().WithMessage(Messages.UserPasswordNotEmpty)
                    .MinimumLength(8).WithMessage(Messages.UserPasswordMin8)
                    .Matches(@"[A-Z]+").WithMessage(Messages.UserPasswordAtLeastUpper)
                    .Matches(@"[a-z]+").WithMessage(Messages.UserPasswordAtLeastLower)
                    .Matches(@"[0-9]+").WithMessage(Messages.UserPasswordAtLeastNumber);
            RuleFor(u => u.PasswordControl).NotEmpty().Equal(u => u.Password).WithMessage(Messages.PasswordConformationMustBeRight);


        }
        private bool UniqueMail(string mail)
        {
            EfTechCareer_Final_DBContext _db = new EfTechCareer_Final_DBContext();
            var user = _db.Users.Where(x => x.Mail.ToLower() == mail.ToLower()).SingleOrDefault();

            if (user == null) return true;
            return false;
        }
    }
}
