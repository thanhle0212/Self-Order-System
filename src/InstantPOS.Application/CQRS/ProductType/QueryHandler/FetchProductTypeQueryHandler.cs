using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.ProductType.Query;
using MediatR;
using InstantPOS.Application.DatabaseServices.Interfaces;
using InstantPOS.Application.Models.ProductType;

namespace InstantPOS.Application.CQRS.ProductType.QueryHandler
{
    public class FetchProductTypeQueryHandler : IRequestHandler<FetchProductTypeQuery, IEnumerable<ProductTypeResponseModel>>
    {
        private readonly IProductTypeDataService _productTypeDataService;

        public FetchProductTypeQueryHandler(IProductTypeDataService productTypeDataService)
        {
            _productTypeDataService = productTypeDataService;
        }

        public async Task<IEnumerable<ProductTypeResponseModel>> Handle(FetchProductTypeQuery request, CancellationToken cancellationToken)
        {
            var result = await _productTypeDataService.FetchProductType();
            
            return result;
        }
    }
}
