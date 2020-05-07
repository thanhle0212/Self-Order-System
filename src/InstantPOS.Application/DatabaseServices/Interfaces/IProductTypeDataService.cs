using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.ProductType.Command;
using InstantPOS.Application.Models.ProductType;

namespace InstantPOS.Application.DatabaseServices.Interfaces
{
    public interface IProductTypeDataService
    {
        Task<bool> CreateProductType(CreateProductTypeCommand request);
        Task<bool> UpdateProductType(UpdateProductTypeCommand request);
        Task<bool> DeleteProductType(Guid productTypeId);
        Task<ProductTypeDetailsResponseModel> GetProductTypeDetails(Guid productTypeId);
        Task<IEnumerable<ProductTypeResponseModel>> FetchProductType();
    }
}
