using Business.Utilities.Messages;
using Data.Concrete.EntityFramework.Context;
using Entities.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class ProductValidation:AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(p => p.Stock).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0).NotEmpty();
            RuleFor(p => p.Name).Must(UniqueName).WithMessage(Messages.ProductMustUniqueName);
            RuleFor(p => p.CategoryID).NotEmpty();
        }
        private bool UniqueName(string name)
        {
            EfTechCareer_Final_DBContext _db = new EfTechCareer_Final_DBContext();
            var product = _db.Products.Where(x => x.Name.ToLower() == name.ToLower()).SingleOrDefault();

            if (product == null) return true;
            return false;
        }

    }
}
