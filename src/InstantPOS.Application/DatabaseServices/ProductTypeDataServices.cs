using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InstantPOS.Application.DatabaseServices;
using InstantPOS.Application.DatabaseServices.Interfaces;
using InstantPOS.Domain.Entities;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace InstantPOS.Infrastructure.DatabaseServices
{
    public class ProductTypeDataServices : IProductTypeDataService
    {
        private readonly IDatabaseConnectionFactory _database;

        public ProductTypeDataServices(IDatabaseConnectionFactory database)
        {
            _database = database;
        }

        public async Task<bool> CreateProductType(ProductType request)
        {
            using var conn = await _database.CreateConnectionAsync();
            var db = new QueryFactory(conn, new SqlServerCompiler());

            if (!await IsProductTypeKeyUnique(db, request.ProductTypeKey, Guid.Empty))
                return false;

            var affectedRecords = await db.Query("ProductType").InsertAsync(new
            {
                ProductTypeId = Guid.NewGuid(),
                ProductTypeKey = request.ProductTypeKey,
                ProductTypeName = request.ProductTypeName,
                RecordStatus = request.RecordStatus,
                CreatedDate = DateTime.UtcNow,
                UpdatedUser = Guid.NewGuid()
            });

            return affectedRecords > 0;
        }

        public async Task<bool> DeleteProductType(Guid productTypeId)
        {
            using var conn = await _database.CreateConnectionAsync();
            var db = new QueryFactory(conn, new SqlServerCompiler());

            var affectedRecord = await db.Query("ProductType").Where("ProductTypeID", "=", productTypeId).DeleteAsync();

            return affectedRecord > 0;
        }

        public async Task<IEnumerable<ProductType>> FetchProductType()
        {
            using var conn = await _database.CreateConnectionAsync();
            var db = new QueryFactory(conn, new SqlServerCompiler());

            var result = db.Query("ProductType");

            return await result.GetAsync<ProductType>();
        }

        public async Task<ProductType> GetProductTypeDetails(Guid productTypeId)
        {
            using var conn = await _database.CreateConnectionAsync();
            var db = new QueryFactory(conn, new SqlServerCompiler());

            var result = db.Query("ProductType").Where("ProductTypeID", "=", productTypeId);

            return await result.FirstOrDefaultAsync<ProductType>();
        }

        public async Task<bool> UpdateProductType(ProductType request)
        {
            using var conn = await _database.CreateConnectionAsync();
            var db = new QueryFactory(conn, new SqlServerCompiler());

            if (!await IsProductTypeKeyUnique(db, request.ProductTypeKey, request.ProductTypeId))
                return false;

            var affectedRecord = await db.Query("ProductType").Where("ProductTypeID", "=", request.ProductTypeId).UpdateAsync(new
            {
                ProductTypeKey = request.ProductTypeKey,
                ProductTypeName = request.ProductTypeName,
                RecordStatus = request.RecordStatus,
                UpdatedDate = DateTime.UtcNow,
                UpdatedUser = Guid.NewGuid()
            }); ;

            return affectedRecord > 0;
        }

        private async Task<bool> IsProductTypeKeyUnique(QueryFactory db, string productTypeKey, Guid productTypeID)
        {
            var result = await db.Query("ProductType").Where("ProductTypeKey", "=", productTypeKey)
                .FirstOrDefaultAsync<ProductType>();

            if (result == null)
                return true;

            return result.ProductTypeId == productTypeID;
        }
    }
}
