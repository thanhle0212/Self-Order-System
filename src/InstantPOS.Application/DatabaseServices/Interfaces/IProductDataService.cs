using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InstantPOS.Domain.Entities;

namespace InstantPOS.Application.DatabaseServices.Interfaces
{
    public interface IProductDataService
    {
        Task<bool> CreateProduct(Product request);
        Task<bool> UpdateProduct(Product request);
        Task<bool> DeleteProduct(Guid productId);
        Task<Product> GetProductDetails(Guid productId);
        Task<IEnumerable<Product>> FetchProduct();
    }
}
