using System.Threading;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.ProductType.Command;
using InstantPOS.Application.Interfaces.DatabaseServices;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.CommandHandler
{
    public class UpdateProductTypeCommandHandler : BaseProductTypeHandler,IRequestHandler<UpdateProductTypeCommand, bool>
    {
        public UpdateProductTypeCommandHandler(IProductTypeDataService productTypeDataService) : base(productTypeDataService)
        {
        }
        public async Task<bool> Handle(UpdateProductTypeCommand request, CancellationToken cancellationToken)
        {
            return await _productTypeDataService.UpdateProductType(request);
        }
    }
}
