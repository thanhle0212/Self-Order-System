using System.Collections.Generic;
using InstantPOS.Application.Models.ProductType;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.Query
{
    public class FetchProductTypeQuery : IRequest<IEnumerable<ProductTypeResponseModel>>
    {
      
    }
}
