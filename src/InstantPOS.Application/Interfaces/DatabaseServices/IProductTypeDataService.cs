using System.Collections.Generic;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.ProductType.Command;
using InstantPOS.Application.CQRS.ProductType.Query;

namespace InstantPOS.Application.Interfaces.DatabaseServices
{
    public interface IProductTypeDataService
    {
        Task<bool> CreateProductType(CreateProductTypeCommand request);
        Task<bool> UpdateProductType(CreateProductTypeCommand request);
        Task<bool> DeleteProductType(CreateProductTypeCommand request);
        Task<Models.ProductType> GetProductTypeDetails(GetProductTypeDetailsQuery request);
        Task<IEnumerable<Models.ProductType>> FetchProductType(FetchProductTypeQuery request);
    }
}
