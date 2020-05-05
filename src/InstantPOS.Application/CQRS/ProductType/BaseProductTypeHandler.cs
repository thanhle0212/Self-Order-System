using InstantPOS.Application.Interfaces.DatabaseServices;

namespace InstantPOS.Application.CQRS.ProductType
{
    public class BaseProductTypeHandler
    {
        public readonly IProductTypeDataService _productTypeDataService;
        public BaseProductTypeHandler(IProductTypeDataService productTypeDataService)
        {
            _productTypeDataService = productTypeDataService;
        }
    }
}
