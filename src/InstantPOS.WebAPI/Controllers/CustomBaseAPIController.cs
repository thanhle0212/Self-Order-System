using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace InstantPOS.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class CustomBaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator;
        public CustomBaseApiController(IMediator mediator)
        {
            _mediator = mediator;
            Mediator = _mediator;
        }

        public CustomBaseApiController()
        {
            if (_mediator == null)
            {
                Mediator = HttpContext.RequestServices.GetService<IMediator>();
            }
        }
    }
}
