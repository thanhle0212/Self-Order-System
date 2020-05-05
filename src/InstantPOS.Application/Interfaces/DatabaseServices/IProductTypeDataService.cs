using System.Collections.Generic;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.ProductType.Command;
using InstantPOS.Application.CQRS.ProductType.Query;
using InstantPOS.Domain.Entities;

namespace InstantPOS.Application.Interfaces.DatabaseServices
{
    public interface IProductTypeDataService
    {
        Task<bool> CreateProductType(CreateProductTypeCommand request);
        Task<bool> UpdateProductType(UpdateProductTypeCommand request);
        Task<bool> DeleteProductType(DeleteProductTypeCommand request);
        Task<ProductType> GetProductTypeDetails(GetProductTypeDetailsQuery request);
        Task<IEnumerable<ProductType>> FetchProductType(FetchProductTypeQuery request);
    }
}
