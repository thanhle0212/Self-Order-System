using System;
using InstantPOS.Domain.Common;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.Command
{
    public class CreateProductTypeCommand : AuditableEntity,IRequest<Guid>
    {
        public Guid ProductTypeId { get; set; }
        public string ProductTypeKey { get; set; }
        public string ProductTypeName { get; set; }
    }
}
