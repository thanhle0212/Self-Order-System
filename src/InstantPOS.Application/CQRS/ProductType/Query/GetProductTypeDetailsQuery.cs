using System;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.Query
{
    public class GetProductTypeDetailsQuery : IRequest<Models.ProductType>
    {
        public Guid ProductTypeId { get; set; }
    }
}
