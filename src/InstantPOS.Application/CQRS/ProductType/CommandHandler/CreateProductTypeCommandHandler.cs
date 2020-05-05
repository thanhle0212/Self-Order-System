using System.Threading;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.ProductType.Command;
using InstantPOS.Application.Interfaces.DatabaseServices;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.CommandHandler
{
    public class CreateProductTypeCommandHandler : IRequestHandler<CreateProductTypeCommand, bool>
    {
        private readonly IProductTypeDataService _productTypeDataService;
        public CreateProductTypeCommandHandler(IProductTypeDataService productTypeDataService)
        {
            _productTypeDataService = productTypeDataService;
        }
        public async Task<bool> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var result = await _productTypeDataService.CreateProductType(request);
            return result;
        }
    }
}
