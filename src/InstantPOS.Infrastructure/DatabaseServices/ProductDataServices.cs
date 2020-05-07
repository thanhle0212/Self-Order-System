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

        public ProductDataServices(IDatabaseConnectionFactory database)
        {
            _database = database;
        }

        public async Task<bool> CreateProduct(CreateProductCommand request)
        {
            using var conn = await _database.CreateConnectionAsync();
            var db = new QueryFactory(conn, new SqlServerCompiler());

            if (!await IsProductKeyUnique(db, request.ProductKey, Guid.Empty))
                return false;

            var affectedRecords = await db.Query("Product").InsertAsync(new
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

        public Task<IEnumerable<ProductResponseModel>> FetchProduct()
        {
            throw new NotImplementedException();
        }

        private async Task<bool> IsProductKeyUnique(QueryFactory db, string productKey, Guid productID)
        {
            var result = await db.Query("Product").Where("ProductKey", "=", productKey)
                .FirstOrDefaultAsync<dynamic>();

            if (result == null)
                return true;

            return result.ProductId == productID;
        }
    }
}
