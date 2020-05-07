using System.ComponentModel;

namespace InstantPOS.Domain.Enums
{
    public enum RecordStatus
    {
        [Description("Active")]
        Active = 1,
        [Description("In active")]
        InActive = 2
    }
}
