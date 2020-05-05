using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InstantPOS.Application.CQRS.ProductType.Command;
using InstantPOS.Application.CQRS.ProductType.Query;
using InstantPOS.Application.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InstantPOS.WebAPI.Controllers
{

    public class ProductTypeController : CustomBaseApiController
    {
        // We can update search criteria later
        [HttpGet]
        public async Task<IEnumerable<ProductType>> Get()
        {
            var query = new FetchProductTypeQuery();
            return await Mediator.Send(query);
        }

        // GET api/ProductType/ProductTypeID
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductType>> Get(Guid id)
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

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
