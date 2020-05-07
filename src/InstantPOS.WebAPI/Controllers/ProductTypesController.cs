using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.ProductType.Command;
using InstantPOS.Application.CQRS.ProductType.Query;
using InstantPOS.Application.Models.ProductType;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InstantPOS.WebAPI.Controllers
{

    public class ProductTypesController : CustomBaseApiController
    {
        // We can update search criteria later
        [HttpGet]
        public async Task<IEnumerable<ProductTypeResponseModel>> Get()
        {
            var query = new FetchProductTypeQuery();
            return await Mediator.Send(query);
        }

        // GET api/ProductType/ProductTypeID
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTypeDetailsResponseModel>> Get(Guid id)
        {
            var query = new GetProductTypeDetailsQuery() { ProductTypeId = id};
            return await Mediator.Send(query);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<bool>> Post(CreateProductTypeCommand command)
        {
            return await Mediator.Send(command);
        }

        // PUT 
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put(Guid id, [FromBody]UpdateProductTypeCommand request)
        {
            request.ProductTypeID = id;
            return await Mediator.Send(request);
        }

        // DELETE 
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            var query = new DeleteProductTypeCommand() { ProductTypeID = id };
            return await Mediator.Send(query);
        }
    }
}
