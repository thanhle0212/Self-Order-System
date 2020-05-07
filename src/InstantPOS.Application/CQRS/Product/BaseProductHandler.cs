using InstantPOS.Application.DatabaseServices.Interfaces;

namespace InstantPOS.Application.CQRS.Product
{
    public class BaseProductHandler
    {
        public readonly IProductDataService _productDataService;
        public BaseProductHandler(IProductDataService productDataService)
        {
            _productDataService = productDataService;
        }
    }
}
