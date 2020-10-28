using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.Product.Command;
using InstantPOS.Application.Models.Product;

namespace InstantPOS.Application.DatabaseServices.Interfaces
{
    public interface IProductDataService
    {
        Task<bool> CreateProduct(CreateProductCommand request);
        Task<bool> DeleteProduct(Guid productTypeId);
        Task<IEnumerable<ProductResponseModel>> FetchProduct(int pageNo, int pageSize);
    }
}
