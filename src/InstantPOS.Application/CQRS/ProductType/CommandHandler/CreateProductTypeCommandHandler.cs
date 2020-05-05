using System;
using System.Threading;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.ProductType.Command;
using InstantPOS.Application.Interfaces.Repositories;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.CommandHandler
{
    public class CreateProductTypeCommandHandler : IRequestHandler<CreateProductTypeCommand, Guid>
    {
        private readonly IProductTypeRepository _productTypeRepository;
        public CreateProductTypeCommandHandler(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }
        public async Task<Guid> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var result = await _productTypeRepository.CreateProductType(request);
            return result;
        }
    }
}
