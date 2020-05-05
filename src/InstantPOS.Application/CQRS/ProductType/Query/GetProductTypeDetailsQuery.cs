using System;
using InstantPOS.Application.DTOs;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.Query
{
    public class GetProductTypeDetailsQuery : IRequest<ProductTypeDto>
    {
        public Guid ProductTypeId { get; set; }
    }
}
