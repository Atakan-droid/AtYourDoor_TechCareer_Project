using Business.Utilities.Messages;
using Data.Concrete.EntityFramework.Context;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class CategoryValidation: AbstractValidator<Category>
    {
        public CategoryValidation()
        {

            RuleFor(c => c.Name).MinimumLength(3).Must(UniqueName).WithMessage(Messages.CategoryMustUniqueName);
        }
        private bool UniqueName(string name)
        {
            EfTechCareer_Final_DBContext _db = new EfTechCareer_Final_DBContext();
            var category = _db.Categories.Where(x => x.Name.ToLower() == name.ToLower()).SingleOrDefault();

            if (category == null) return true;
            return false;
        }
    }
}
