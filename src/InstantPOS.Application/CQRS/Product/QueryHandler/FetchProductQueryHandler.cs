using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.Product.Query;
using InstantPOS.Application.DatabaseServices.Interfaces;
using InstantPOS.Application.Models.Product;
using MediatR;

namespace InstantPOS.Application.CQRS.Product.QueryHandler
{
    public class FetchProductQueryHandler : BaseProductHandler, IRequestHandler<FetchProductQuery, IEnumerable<ProductResponseModel>>
    {
        public FetchProductQueryHandler(IProductDataService productDataService): base(productDataService)
        {
        }
        public async Task<IEnumerable<ProductResponseModel>> Handle(FetchProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _productDataService.FetchProduct(request.PageNo, request.PageSize);

            return result;
        }
    }
}
