using System;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.Command
{
    public class UpdateProductTypeCommand : IRequest<bool>
    {
        public Guid ProductTypeID { get; set; }
        public string ProductTypeKey { get; set; }
        public string ProductTypeName { get; set; }
        public int RecordStatus { get; set; }
    }
}
