using Business.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        Result<Product> AddProduct(Product product);
        Result<Product> UpdateProduct(int productId,Product product);
        Result<Product> DeleteProduct(int productId);
        Result<Product> HardDeleteProduct(int productId);
        Result<Product> GetProductById(int productId);
        void ChangeProductsStockAfterOrder(List<Product> products,List<ProductToOrderDTO> numberOfProductStock);
        Result<List<Product>> CheckProductsStock(List<ProductToOrderDTO> products);
        Result<List<Product>> GetProductsByCategoryId(int categoryId);
        Result<List<Product>> GetProducts();
    }
}
