using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("errors/{code}")]
    public class RedirectErrorcontroller: Basecontroller
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ErrorResponse(code));
        }
    }
}