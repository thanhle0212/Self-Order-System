using InstantPOS.Domain.Entities;
using InstantPOS.Domain.Enums;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.Command
{
    public class CreateProductTypeCommand : IRequest<bool>
    {
        public string ProductTypeKey { get; set; }
        public string ProductTypeName { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
