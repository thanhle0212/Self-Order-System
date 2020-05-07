using System;
using InstantPOS.Domain.Enums;

namespace InstantPOS.Application.Models.ProductType
{
    public class ProductTypeResponseModel
    {
        public Guid ProductTypeId { get; set; }
        public string ProductTypeKey { get; set; }
        public string ProductTypeName { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
