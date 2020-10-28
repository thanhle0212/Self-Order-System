using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.Product.Command;
using InstantPOS.Application.DatabaseServices.Interfaces;
using InstantPOS.Application.Models.Product;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace InstantPOS.Infrastructure.DatabaseServices   
{
    public class ProductDataServices : IProductDataService
    {
        private readonly IDatabaseConnectionFactory _database;
        private readonly QueryFactory _db;

        public ProductDataServices(IDatabaseConnectionFactory database, QueryFactory db)
        {
            _database = database;
            _db = db;
        }

        public async Task<bool> CreateProduct(CreateProductCommand request)
        {
            if (!await IsProductKeyUnique(request.ProductKey, Guid.Empty))
                return false;

            var affectedRecords = await _db.Query("Product").InsertAsync(new
            {
                ProductId = Guid.NewGuid(),
                ProductKey = request.ProductKey,
                ProductName = request.ProductName,
                ProductImageUri = request.ProductImageUri,
                ProductTypeID = request.ProductTypeID,
                RecordStatus = request.RecordStatus,
                CreatedDate = DateTime.UtcNow,
                UpdatedUser = Guid.NewGuid()
            });

            return affectedRecords > 0;
        }

        public Task<bool> DeleteProduct(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductResponseModel>> FetchProduct(int pageNo, int pageSize)
        {

            var result = _db.Query("Product")
                .Select(
                "ProductID",
                "ProductKey",
                "ProductName",
                "ProductImageUri",
                "ProductTypeName",
                "Product.RecordStatus")
                .Join("ProductType", "ProductType.ProductTypeID", "Product.ProductTypeID")
                .OrderByDesc("Product.UpdatedDate")
                .OrderByDesc("Product.CreatedDate")
                .ForPage(pageNo, pageSize); 

            return await result.GetAsync<ProductResponseModel>();
        }

        private async Task<bool> IsProductKeyUnique(string productKey, Guid productID)
        {
            var result = await _db.Query("Product").Where("ProductKey", "=", productKey)
                .FirstOrDefaultAsync<ProductResponseModel>();

            if (result == null)
                return true;

            return result.ProductID == productID;
        }
    }
}
