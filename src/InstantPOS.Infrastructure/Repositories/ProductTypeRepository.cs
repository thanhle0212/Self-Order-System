using System;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.ProductType.Command;
using InstantPOS.Application.Interfaces.Repositories;

namespace InstantPOS.Infrastructure.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        public async Task<Guid> CreateProductType(CreateProductTypeCommand request)
        {
            return Guid.NewGuid();
        }
    }
}
