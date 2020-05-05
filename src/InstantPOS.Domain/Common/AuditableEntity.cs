using System;
namespace InstantPOS.Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedUser { get; set; }
    }
}
