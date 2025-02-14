using Core.Utilities.Results.MVC.BaseResult;
using Microsoft.AspNetCore.Mvc;

namespace Core.Extentions.Concrete.Controller.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumeApiController : ControllerBase
    {
        [NonAction]
        public IActionResult ActionResultInstance<T>(IApiDataResult<T> response) where T : class
        {
            return new ObjectResult(response.Data)
            {
                StatusCode = Convert.ToInt32(response.Status)
            };
        }

        [NonAction]
        public IActionResult ActionResultInstance(IApiResult response)
        {
            return new ObjectResult(null)
            {
                StatusCode = Convert.ToInt32(response.Status)
            };
        }
    }
}
