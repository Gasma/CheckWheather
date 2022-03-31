using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Upstart13.Api.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private IMediator? _mediator;

        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
    }
}
