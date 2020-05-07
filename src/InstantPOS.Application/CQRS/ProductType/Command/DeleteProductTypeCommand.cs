using System;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.Command
{
    public class DeleteProductTypeCommand : IRequest<bool>
    {
        public Guid ProductTypeID { get; set; }
    }
}
