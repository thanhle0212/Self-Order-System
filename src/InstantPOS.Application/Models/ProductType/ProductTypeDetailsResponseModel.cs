using System;
using InstantPOS.Domain.Entities;
using InstantPOS.Domain.Enums;

namespace InstantPOS.Application.Models.ProductType
{
    public class ProductTypeDetailsResponseModel: AuditableEntity
    {
        public Guid ProductTypeID { get; set; }
        public string ProductTypeKey { get; set; }
        public string ProductTypeName { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public string RecordStatusName { get; set; }
    }
}
