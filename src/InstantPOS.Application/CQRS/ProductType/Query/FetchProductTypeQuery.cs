using System.Collections.Generic;
using InstantPOS.Application.DTOs;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.Query
{
    public class FetchProductTypeQuery : IRequest<IEnumerable<ProductTypeDto>>
    {
      
    }
}
