using Hospital.Model;
using Medical.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreesController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public DegreesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //get Api/Degrees
        [HttpGet]
        public IEnumerable<Degree> Get()
        {
            return _context.Degree.ToList();
        }
        [HttpGet("Id")]
        public ActionResult<Degree> Get(int id) 
        {
            var degree = _context.Degree.Find(id);
            if (degree == null)
            {
                return NotFound();
            }
            return Ok(degree);
        }

        //post Api/ Degrees
        [HttpPost]
        public IActionResult Post([FromBody] Degree degree)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Degree.Add(degree);
            _context.SaveChanges();
            return CreatedAtRoute(new {id = degree.Id},degree);
        }

    }
}
