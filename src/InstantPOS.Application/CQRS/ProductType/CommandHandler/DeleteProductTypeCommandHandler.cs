using System;
using System.Threading;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.ProductType.Command;
using InstantPOS.Application.Interfaces.DatabaseServices;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.CommandHandler
{
    public class DeleteProductTypeCommandHandler : BaseProductTypeHandler,IRequestHandler<DeleteProductTypeCommand, bool>
    {
        public DeleteProductTypeCommandHandler(IProductTypeDataService productTypeDataService) : base(productTypeDataService)
        {
        }
        public async Task<bool> Handle(DeleteProductTypeCommand request, CancellationToken cancellationToken)
        {
           return await _productTypeDataService.DeleteProductType(request);
        }
    }
}
