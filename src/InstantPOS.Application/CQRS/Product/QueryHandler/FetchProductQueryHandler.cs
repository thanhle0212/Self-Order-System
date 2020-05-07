using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstantPOS.Application.CQRS.Product.Query;
using InstantPOS.Application.DatabaseServices.Interfaces;
using InstantPOS.Application.Models.Product;
using MediatR;

namespace InstantPOS.Application.CQRS.Product.QueryHandler
{
    public class FetchProductQueryHandler : IRequestHandler<FetchProductQuery, IEnumerable<ProductResponseModel>>
    {
        private readonly IProductDataService _productDataService;
        private readonly IMapper _mapper;

        public FetchProductQueryHandler(IProductDataService productDataService, IMapper mapper)
        {
            _productDataService = productDataService;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductResponseModel>> Handle(FetchProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _productDataService.FetchProduct();

            return result;
        }
    }
}
