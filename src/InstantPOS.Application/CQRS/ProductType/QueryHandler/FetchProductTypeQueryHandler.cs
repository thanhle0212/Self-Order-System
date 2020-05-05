using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.ProductType.Query;
using InstantPOS.Application.Interfaces.DatabaseServices;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.QueryHandler
{
    public class FetchProductTypeQueryHandler : IRequestHandler<FetchProductTypeQuery, IEnumerable<Models.ProductType>>
    {
        private readonly IProductTypeDataService _productTypeDataService;
        public FetchProductTypeQueryHandler(IProductTypeDataService productTypeDataService)
        {
            _productTypeDataService = productTypeDataService;
        }
        public async Task<IEnumerable<Models.ProductType>> Handle(FetchProductTypeQuery request, CancellationToken cancellationToken)
        {
            return await _productTypeDataService.FetchProductType(request);
        }
    }
}
