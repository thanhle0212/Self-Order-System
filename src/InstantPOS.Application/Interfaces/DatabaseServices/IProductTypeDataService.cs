using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InstantPOS.Domain.Entities;

namespace InstantPOS.Application.Interfaces.DatabaseServices
{
    public interface IProductTypeDataService
    {
        Task<bool> CreateProductType(ProductType request);
        Task<bool> UpdateProductType(ProductType request);
        Task<bool> DeleteProductType(Guid productTypeId);
        Task<ProductType> GetProductTypeDetails(Guid productTypeId);
        Task<IEnumerable<ProductType>> FetchProductType();
    }
}
