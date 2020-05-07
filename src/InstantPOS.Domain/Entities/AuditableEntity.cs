using System;
namespace InstantPOS.Domain.Entities
{
    public class AuditableEntity
    {
        public Guid UpdatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
