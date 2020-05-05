using System.Collections.Generic;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.Query
{
    public class FetchProductTypeQuery : IRequest<IEnumerable<Models.ProductType>>
    {
      
    }
}
