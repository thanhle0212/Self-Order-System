using System.Threading;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.ProductType.Command;
using InstantPOS.Application.DatabaseServices.Interfaces;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.CommandHandler
{
    public class CreateProductTypeCommandHandler : BaseProductTypeHandler, IRequestHandler<CreateProductTypeCommand, bool>
    {
        public CreateProductTypeCommandHandler(IProductTypeDataService productTypeDataService) : base(productTypeDataService)
        {
        }

        public async Task<bool> Handle(CreateProductTypeCommand createProductTypeCommandRequest, CancellationToken cancellationToken)
        {
            var result = await base._productTypeDataService.CreateProductType(createProductTypeCommandRequest);
            return result;
        }
    }
}
