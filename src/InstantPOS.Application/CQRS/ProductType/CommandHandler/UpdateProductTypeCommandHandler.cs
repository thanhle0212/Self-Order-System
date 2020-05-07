using System.Threading;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.ProductType.Command;
using InstantPOS.Application.DatabaseServices.Interfaces;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.CommandHandler
{
    public class UpdateProductTypeCommandHandler : BaseProductTypeHandler,IRequestHandler<UpdateProductTypeCommand, bool>
    {
        public UpdateProductTypeCommandHandler(IProductTypeDataService productTypeDataService) : base(productTypeDataService)
        {
        }
        public async Task<bool> Handle(UpdateProductTypeCommand updateProductTypeCommandRequest, CancellationToken cancellationToken)
        {
            var result = await base._productTypeDataService.UpdateProductType(updateProductTypeCommandRequest);
            return result;
        }
    }
}
