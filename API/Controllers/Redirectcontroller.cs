using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi =true)]

    public class RedirectErrorcontroller: Basecontroller
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ErrorResponse(code));
        }
    }
}