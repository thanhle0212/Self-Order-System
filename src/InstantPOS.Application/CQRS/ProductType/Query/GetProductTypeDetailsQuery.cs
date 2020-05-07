using System;
using InstantPOS.Application.Models.ProductType;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.Query
{
    public class GetProductTypeDetailsQuery : IRequest<ProductTypeDetailsResponseModel>
    {
        public Guid ProductTypeId { get; set; }
    }
}
