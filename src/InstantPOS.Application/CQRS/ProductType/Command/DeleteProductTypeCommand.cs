using System;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.Command
{
    public class DeleteProductTypeCommand : IRequest<bool>
    {
        public Guid ProductTypeId { get; set; }
    }
}
