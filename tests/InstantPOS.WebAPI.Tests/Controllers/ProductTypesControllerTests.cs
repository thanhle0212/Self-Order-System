using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.ProductType.Command;
using InstantPOS.Application.CQRS.ProductType.Query;
using InstantPOS.Application.Models.ProductType;
using InstantPOS.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace InstantPOS.WebAPI.Tests.Controllers
{
    public class ProductTypesControllerTests: BaseAPITest
    {
        [Fact]
        public async Task GetProductTypes_ValidRequest_SuccessResult()
        {
            var response = new List<ProductTypeResponseModel>();
            response.Add(new ProductTypeResponseModel
            {
                ProductTypeID = Guid.NewGuid(),
                ProductTypeKey = "ProductKey",
                ProductTypeName = "ProductTypeName"
            });

            //Arrange
            BaseMediator.Setup(x => x.Send(It.IsAny<FetchProductTypeQuery>(), new CancellationToken())).
                ReturnsAsync(response);
            var productTypesController = new ProductTypesController(BaseMediator.Object);

            //Action
            var result = await productTypesController.Get();

            //Assert
            Assert.IsType<List<ProductTypeResponseModel>>(result);
        }


        [Fact]
        public async Task GetProductTypeDetailsById_ValidRequest_SuccessResult()
        {
            var productTypeId = Guid.NewGuid();
            var response = new ProductTypeDetailsResponseModel
            {
                ProductTypeID = productTypeId,
                ProductTypeKey = "ProductKey",
                ProductTypeName = "ProductTypeName"
            };


            //Arrange
            BaseMediator.Setup(x => x.Send(It.IsAny<GetProductTypeDetailsQuery>(), new CancellationToken())).
                ReturnsAsync(response);
            var productTypesController = new ProductTypesController(BaseMediator.Object);

            //Action
            var result = await productTypesController.Get(productTypeId);

            //Assert
            Assert.IsType<ActionResult<ProductTypeDetailsResponseModel>>(result);
        }

        [Fact]
        public async Task CreateProductType_ValidRequest_SuccessResult()
        {
            var requestModel = new CreateProductTypeCommand
            {
                ProductTypeKey = "ProductKey",
                ProductTypeName = "ProductTypeName"
            };


            //Arrange
            BaseMediator.Setup(x => x.Send(requestModel, new CancellationToken())).
                ReturnsAsync(true);
            var productTypesController = new ProductTypesController(BaseMediator.Object);

            //Action
            var result = await productTypesController.Post(requestModel);

            //Assert
            Assert.True(result.Value);
        }

        [Fact]
        public async Task UpdateProductType_ValidRequest_SuccessResult()
        {
            var id = Guid.NewGuid();
            var requestModel = new UpdateProductTypeCommand
            {
                ProductTypeKey = "ProductKey",
                ProductTypeName = "ProductTypeName"
            };


            //Arrange
            BaseMediator.Setup(x => x.Send(requestModel, new CancellationToken())).
                ReturnsAsync(true);
            var productTypesController = new ProductTypesController(BaseMediator.Object);

            //Action
            var result = await productTypesController.Put(id, requestModel);

            //Assert
            Assert.True(result.Value);
        }

        [Fact]
        public async Task DeleteProductType_ValidRequest_SuccessResult()
        {
            var id = Guid.NewGuid();

            //Arrange
            BaseMediator.Setup(x => x.Send(It.IsAny<DeleteProductTypeCommand>(), new CancellationToken())).
                ReturnsAsync(true);
            var productTypesController = new ProductTypesController(BaseMediator.Object);

            //Action
            var result = await productTypesController.Delete(id);

            //Assert
            Assert.True(result.Value);
        }
    }
}
