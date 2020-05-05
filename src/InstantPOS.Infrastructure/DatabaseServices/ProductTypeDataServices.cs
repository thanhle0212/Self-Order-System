using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.ProductType.Command;
using InstantPOS.Application.CQRS.ProductType.Query;
using InstantPOS.Application.Interfaces.DatabaseServices;
using InstantPOS.Domain.Entities;
using InstantPOS.Domain.Enums;
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

        public async Task<bool> CreateProductType(CreateProductTypeCommand request)
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
                RecordStatus = RecordStatus.Active,
                CreatedDate = DateTime.UtcNow,
                UpdatedUser = Guid.NewGuid()
            });

            return affectedRecords > 0;
        }

        public async Task<bool> DeleteProductType(DeleteProductTypeCommand request)
        {
            using var conn = await _database.CreateConnectionAsync();
            var db = new QueryFactory(conn, new SqlServerCompiler());

            var affectedRecord = await db.Query("ProductType").Where("ProductTypeID", "=", request.ProductTypeId).DeleteAsync();

            return affectedRecord > 0;
        }

        public async Task<IEnumerable<ProductType>> FetchProductType(FetchProductTypeQuery request)
        {
            using var conn = await _database.CreateConnectionAsync();
            var db = new QueryFactory(conn, new SqlServerCompiler());

            var result = db.Query("ProductType");

            return await result.GetAsync<ProductType>();
        }

        public async Task<ProductType> GetProductTypeDetails(GetProductTypeDetailsQuery request)
        {
            using var conn = await _database.CreateConnectionAsync();
            var db = new QueryFactory(conn, new SqlServerCompiler());

            var result = db.Query("ProductType").Where("ProductTypeID", "=", request.ProductTypeId);

            return await result.FirstOrDefaultAsync<ProductType>();
        }

        public async Task<bool> UpdateProductType(UpdateProductTypeCommand request)
        {
            using var conn = await _database.CreateConnectionAsync();
            var db = new QueryFactory(conn, new SqlServerCompiler());

            if (!await IsProductTypeKeyUnique(db, request.ProductTypeKey, request.ProductTypeId))
                return false;

            var affectedRecord = await db.Query("ProductType").Where("ProductTypeID", "=", request.ProductTypeId).UpdateAsync(new
            {
                ProductTypeKey = request.ProductTypeKey,
                ProductTypeName = request.ProductTypeName,
                UpdatedDate = DateTime.UtcNow,
                UpdatedUser = Guid.NewGuid()
            });

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
