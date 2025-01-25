using Hospital.Model;
using Medical.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialInterestsController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public SpecialInterestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get Api/SpecialInterests 
        [HttpGet]
        public IEnumerable<SpecialInterest> Get()
        {
            return _context.SpecialInterests.ToList();
        }

        //Get Api/SpecialInterests/2
        [HttpGet("{id}")]
        public ActionResult<SpecialInterest> Get(int id)
        {
            var specialinterest = _context.SpecialInterests.Find(id);
            if (specialinterest == null)
            {
                return NotFound();
            }
            return Ok(specialinterest);

        }

        //Post Api/SpecialInterest
        [HttpPost]
        public IActionResult Post([FromBody] SpecialInterest specialinterest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.SpecialInterests.Add(specialinterest);
            _context.SaveChanges();
            return CreatedAtRoute(new { id = specialinterest.Id }, specialinterest);

        }

        //Put Api/SpecialInterest
        [HttpPut]
        public IActionResult Put(int id, [FromBody] SpecialInterest specialinterest)
        {
            var existingSpecialInterest = _context.SpecialInterests.Find(id);
            if (existingSpecialInterest == null)
            {
                return NotFound();
            }

            existingSpecialInterest.Name = specialinterest.Name;
            _context.SaveChanges();
            return Ok(existingSpecialInterest);

        }

        //Delete api/SpecialInterest
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var specialinterest = _context.SpecialInterests.Find(id);
            if (specialinterest == null)
            {
                return NotFound();
            }

            _context.SpecialInterests.Remove(specialinterest);
            _context.SaveChanges();
            return Ok();
        }

    }
}
