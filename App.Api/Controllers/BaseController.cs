using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(App.Services.ServiceResult<T> serviceResult)
        {
            if (serviceResult.Status == System.Net.HttpStatusCode.NoContent)
            {
                return NoContent();
            }
            if (serviceResult.Status == HttpStatusCode.Created) { 
                return Created(serviceResult.UrlAsCreated ?? string.Empty, serviceResult.Data);
            }
            return new ObjectResult(serviceResult) { StatusCode = serviceResult.Status.GetHashCode() };
        }
        [NonAction]
        public IActionResult CreateActionResult(App.Services.ServiceResult serviceResult)
        {
            if (serviceResult.Status == System.Net.HttpStatusCode.NoContent)
            {
                return new ObjectResult(null) { StatusCode = serviceResult.Status.GetHashCode() };
            }
            return new ObjectResult(serviceResult) { StatusCode = serviceResult.Status.GetHashCode() };
        }
    }
}
