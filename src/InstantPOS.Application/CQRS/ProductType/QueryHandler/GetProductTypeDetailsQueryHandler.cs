using System;
using System.Threading;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.ProductType.Query;
using InstantPOS.Application.Interfaces.DatabaseServices;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.QueryHandler
{
    public class GetProductTypeDetailsQueryHandler: IRequestHandler<GetProductTypeDetailsQuery, Models.ProductType>
    {
        private readonly IProductTypeDataService _productTypeDataService;
        public GetProductTypeDetailsQueryHandler(IProductTypeDataService productTypeDataService)
        {
            _productTypeDataService = productTypeDataService;
        }
        public async Task<Models.ProductType> Handle(GetProductTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _productTypeDataService.GetProductTypeDetails(request);
        }
    }
}
