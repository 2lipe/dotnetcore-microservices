using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BaseController : ControllerBase
    {
        public BaseController()
        {
        }
        
        #region [IMediator] sync
        
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>(); 
        
        #endregion [IMediator] async
        
        #region [ActionResult] sync

        protected ActionResult Result<TData>(TData data) where TData : class
        {
            return new JsonResult(
                new
                {
                    Success = true,
                    Data = data
                });
        }

        protected ActionResult Result()
        {
            return new JsonResult(
                new
                {
                    Success = true,
                    Data = "Success!"
                });
        }

        #endregion [ActionResult] async
        
        #region [IActionResult] sync
        
        protected IActionResult Ok()
        {
            return new JsonResult(
                new
                {
                    Success = true,
                    Data = "Success!"
                });
        }

        #endregion [IActionResult] async
    }
}