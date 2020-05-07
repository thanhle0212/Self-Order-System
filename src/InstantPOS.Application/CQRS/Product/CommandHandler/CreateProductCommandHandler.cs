using System.Threading;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.Product.Command;
using InstantPOS.Application.DatabaseServices.Interfaces;
using MediatR;

namespace InstantPOS.Application.CQRS.Product.CommandHandler
{
    public class CreateProductCommandHandler : BaseProductHandler, IRequestHandler<CreateProductCommand, bool>
    {
        public CreateProductCommandHandler(IProductDataService productDataService) : base(productDataService)
        {
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var result = await base._productDataService.CreateProduct(request);
            return result;
        }
    }
}
