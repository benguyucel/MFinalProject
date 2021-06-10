using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetProducts();
        IDataResult<List<Product>> GetProductsByCategoryId(int Id);
        IDataResult<List<Product>> GetProductsByUnitPrice(decimal min,decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetProductById(int productId);
        IResult Add(Product product);
    }
}
