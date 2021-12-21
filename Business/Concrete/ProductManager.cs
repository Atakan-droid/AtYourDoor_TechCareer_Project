using Business.Abstract;
using Business.Utilities.Messages;
using Business.Utilities.Result;
using Business.Validation.FluentValidation;
using Data.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        public IProductDal _productDal;
        public ICategoryDal _categoryDal;
        public ProductManager(IProductDal productDal,ICategoryDal categoryDal)
        {
            _productDal = productDal;
            _categoryDal = categoryDal;
        }
        public Result<Product> AddProduct(Product product)
        {
            var result = ValidateProduct(product);
            if (result.IsValid)
            {
                product.DiscountedUnitPrice = product.UnitPrice - (product.UnitPrice * (product.Discount / 100));
                _productDal.Add(product);
                return new Result<Product>(product, true, Messages.ProductAdded);
            }
            else
            {
                List<string> errorList = new List<string>();
                foreach (var error in result.Errors)
                {
                    errorList.Add(error.PropertyName + " : " + error.ErrorMessage);
                }
                return new Result<Product>(errorList,false,Messages.ProductError);
            }
           

        }
        public Result<Product> DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                product.Data.IsDeleted = true;
                product.Data.ModifiedDate = DateTime.Now;
                _productDal.Update(product.Data);
                return new Result<Product>(product.Data,true,Messages.ProductDeleted);
            }
            else
            {
                return new Result<Product>(false, Messages.ProductNotFound);
            }
        }
        public Result<Product> HardDeleteProduct(int productId)
        {
            var product = GetProductById(productId);
            if (product != null)
            {
                _productDal.Delete(product.Data);
                return new Result<Product>(true,Messages.ProductDeleted);
            }
            else
            {
                return new Result<Product>(false,Messages.ProductNotFound);
            }
        }

        public Result<Product> UpdateProduct(int productId,Product product)
        {

       
                var productToUpdate = GetProductById(productId);
                if (productToUpdate.Success)
                {
                    productToUpdate.Data.Name = product.Name;
                    productToUpdate.Data.Stock = product.Stock;
                    productToUpdate.Data.UnitPrice = product.UnitPrice;
                    productToUpdate.Data.IsDeleted = product.IsDeleted;
                    productToUpdate.Data.ModifiedDate = DateTime.Now;
                    _productDal.Update(productToUpdate.Data);
                    return new Result<Product>(productToUpdate.Data, true, Messages.ProductUpdated);
                }
                return new Result<Product>(false,Messages.ProductNotFound);
          
        }

        public Result<Product> GetProductById(int productId)
        {
            Product product = _productDal.Get(p => p.Id == productId && p.IsDeleted == false);
            if (product != null)
            {
                return new Result<Product>(product, true, Messages.ProductGet);
            }
            else
            {
                return new Result<Product>(false, Messages.ProductNotFound);
            }
        }

        public Result<List<Product>> GetProducts()
        {
            List<Product> products = _productDal.GetAll();
            return new Result<List<Product>>(products,true,Messages.ProductGet);
        }

        public Result<List<Product>> GetProductsByCategoryId(int categoryId)
        {
            var result = _categoryDal.Get(c => c.Id == categoryId && c.IsDeleted == false);
            if (result != null)
            {
                List<Product> products = _productDal.GetAll(c => c.CategoryID == categoryId).ToList();
                return new Result<List<Product>>(products,true,Messages.ProductGet);
            }
            else
            {
                return new Result<List<Product>>(false,Messages.CategoryNotFound);
            }
        }

        private ValidationResult ValidateProduct(Product product)
        {
            ProductValidation rules = new ProductValidation();
            ValidationResult result = rules.Validate(product);
            return result;
        }
        public Result<List<Product>> CheckProductsStock(List<ProductToOrderDTO> products)
        {
            List<Product> productsToAdd = new List<Product>();
            foreach (var finProduct in products)
            {
                var product = _productDal.Get(p=>p.Id== finProduct.productId);
                if (product==null) { return new Result<List<Product>>(false, Messages.ProductNotFound); }
                if (product.Stock < finProduct.Number) { return new Result<List<Product>>(false, Messages.ProductNotEnoughStock); }
                productsToAdd.Add(product);
            }
            return new Result<List<Product>>(productsToAdd,true,Messages.ProductGet);
        }
            public void ChangeProductsStockAfterOrder(List<Product> products, List<ProductToOrderDTO> order)
        {
            for (int i = 0; i < products.Count; i++)
            {
                products[i].Stock = products[i].Stock - order[i].Number;
                _productDal.Update(products[i]);
            }
        }
    }
}
