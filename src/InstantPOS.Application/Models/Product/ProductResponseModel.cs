using InstantPOS.Domain.Enums;

namespace InstantPOS.Application.Models.Product
{
    public class ProductResponseModel
    {
        public string ProductKey { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUri { get; set; }
        public string ProductTypeName { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
