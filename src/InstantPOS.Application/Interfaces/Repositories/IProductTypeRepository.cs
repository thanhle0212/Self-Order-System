using System;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.ProductType.Command;

namespace InstantPOS.Application.Interfaces.Repositories
{
    public interface IProductTypeRepository
    {
        Task<Guid> CreateProductType(CreateProductTypeCommand request);
    }
}
