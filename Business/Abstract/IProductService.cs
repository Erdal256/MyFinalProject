using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll(); // tümünü getir
        List<Product> GetAllByCategoryId(int id); // categori idsine göre getir.
        List<Product> GetByUnitPrice(decimal min,decimal max);

        List<ProductDetailDto> GetProductDetails();
    }
}