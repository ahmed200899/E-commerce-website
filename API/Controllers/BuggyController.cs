using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class BuggyController : Basecontroller
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _context.Products.Find(42);
            if (thing == null)
            {
                return NotFound(new ErrorResponse(404));
            }
            else
                return Ok();
        }

        [HttpGet("ServerError")]
        public ActionResult Getservererr()
        {
            var thing = _context.Products.Find(42);
            var newtihng = thing.ToString();
            return Ok();
        }

        [HttpGet("BadRequest")]
        public ActionResult GetBadRes()
        {
            return BadRequest(new ErrorResponse(400));
        }

        [HttpGet("BadRequest/{id}")]
        public ActionResult GetNotFoundRes(int id)
        {
            return Ok();
        }

    }
}