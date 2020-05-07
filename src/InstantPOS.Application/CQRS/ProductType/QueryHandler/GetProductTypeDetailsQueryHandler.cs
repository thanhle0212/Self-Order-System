using System.Threading;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.ProductType.Query;
using InstantPOS.Application.DatabaseServices.Interfaces;
using InstantPOS.Application.Models.ProductType;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.QueryHandler
{
    public class GetProductTypeDetailsQueryHandler: IRequestHandler<GetProductTypeDetailsQuery, ProductTypeDetailsResponseModel>
    {
        private readonly IProductTypeDataService _productTypeDataService;
        public GetProductTypeDetailsQueryHandler(IProductTypeDataService productTypeDataService)
        {
            _productTypeDataService = productTypeDataService;
        }
        public async Task<ProductTypeDetailsResponseModel> Handle(GetProductTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = await _productTypeDataService.GetProductTypeDetails(request.ProductTypeId);

            return result;
        }
    }
}
