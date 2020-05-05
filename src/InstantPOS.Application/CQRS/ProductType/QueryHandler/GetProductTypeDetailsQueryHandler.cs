using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstantPOS.Application.CQRS.ProductType.Query;
using InstantPOS.Application.DTOs;
using InstantPOS.Domain.Entities;
using InstantPOS.Application.Interfaces.DatabaseServices;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.QueryHandler
{
    public class GetProductTypeDetailsQueryHandler: IRequestHandler<GetProductTypeDetailsQuery, ProductTypeDto>
    {
        private readonly IProductTypeDataService _productTypeDataService;
        private readonly IMapper _mapper;
        public GetProductTypeDetailsQueryHandler(IProductTypeDataService productTypeDataService, IMapper mapper)
        {
            _productTypeDataService = productTypeDataService;
            _mapper = mapper;
        }
        public async Task<ProductTypeDto> Handle(GetProductTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = await _productTypeDataService.GetProductTypeDetails(request);
            
            return _mapper.Map<InstantPOS.Domain.Entities.ProductType, ProductTypeDto>(result);

        }
    }
}
