using System.Threading;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.ProductType.Command;
using InstantPOS.Application.Interfaces.DatabaseServices;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.CommandHandler
{
    public class CreateProductTypeCommandHandler : BaseProductTypeHandler, IRequestHandler<CreateProductTypeCommand, bool>
    {
        public CreateProductTypeCommandHandler(IProductTypeDataService productTypeDataService): base(productTypeDataService)
        {
        }
        public async Task<bool> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var result = await base._productTypeDataService.CreateProductType(request);
            return result;
        }
    }
}
