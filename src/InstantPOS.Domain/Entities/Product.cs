using System;
using InstantPOS.Domain.Common;

namespace InstantPOS.Domain.Entities
{
    public class Product: AuditableEntity
    {
        public Guid ProductId { get; set; }
        public string ProductKey { get; set; }
        public string ProductName { get; set; }
        public ProductType ProductType { get; set; }
    }
}
