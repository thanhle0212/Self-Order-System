using System;
using InstantPOS.Domain.Common;
using InstantPOS.Domain.Enums;

namespace InstantPOS.Domain.Entities
{
    public class ProductType : AuditableEntity
    {
        public Guid ProductTypeId { get; set; }
        public string ProductTypeKey { get; set; }
        public string ProductTypeName { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
