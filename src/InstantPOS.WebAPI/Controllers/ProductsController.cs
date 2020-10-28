using InstantPOS.Application.CQRS.Product.Command;
using InstantPOS.Application.CQRS.Product.Query;
using InstantPOS.Application.Models.Product;
using InstantPOS.WebAPI.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InstantPOS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    //[Authorize(Policy = AuthorizationConsts.AdministrationPolicy)]

    public class ProductsController : CustomBaseApiController
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {

        }
        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<ProductResponseModel>> Get(int pageNo, int pageSize)
        {
            var query = new FetchProductQuery() { PageNo = pageNo, PageSize = pageSize };
            return await Mediator.Send(query);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<bool>> Post(CreateProductCommand command)
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
