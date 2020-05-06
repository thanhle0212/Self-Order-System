using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.ProductType.Query;
using InstantPOS.Application.DTOs;
using MediatR;
using AutoMapper;
using InstantPOS.Application.DatabaseServices.Interfaces;

namespace InstantPOS.Application.CQRS.ProductType.QueryHandler
{
    public class FetchProductTypeQueryHandler : IRequestHandler<FetchProductTypeQuery, IEnumerable<ProductTypeDto>>
    {
        private readonly IProductTypeDataService _productTypeDataService;
        private readonly IMapper _mapper;

        public FetchProductTypeQueryHandler(IProductTypeDataService productTypeDataService, IMapper mapper)
        {
            _productTypeDataService = productTypeDataService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductTypeDto>> Handle(FetchProductTypeQuery request, CancellationToken cancellationToken)
        {
            var result = await _productTypeDataService.FetchProductType();

            return _mapper.Map< IEnumerable<InstantPOS.Domain.Entities.ProductType>, IEnumerable<ProductTypeDto>>(result);
        }
    }
}
