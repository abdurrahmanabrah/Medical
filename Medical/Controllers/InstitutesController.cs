using Hospital.Model;
using Medical.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutesController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public InstitutesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get Api/Institutes 
        [HttpGet]
        public IEnumerable<Institute> Get()
        {
            return _context.Institutes.ToList();
        }

        //Get Api/Institutes/2
        [HttpGet("{id}")]
        public ActionResult<Institute> Get(int id)
        {
            var institute = _context.Institutes.Find(id);
            if (institute == null)
            {
                return NotFound();
            }
            return Ok(institute);

        }

        //Post Api/Institute
        [HttpPost]
        public IActionResult Post([FromBody] Institute institute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Institutes.Add(institute);
            _context.SaveChanges();
            return CreatedAtRoute(new { id = institute.Id }, institute);

        }

        //Put Api/Institute
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Institute institute)
        {
            var existingInstitute = _context.Institutes.Find(id);
            if (existingInstitute == null)
            {
                return NotFound();
            }

            existingInstitute.Name = institute.Name;
            _context.SaveChanges();
            return Ok(existingInstitute);

        }

        //Delete api/Institute
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var institute = _context.Institutes.Find(id);
            if (institute == null)
            {
                return NotFound();
            }

            _context.Institutes.Remove(institute);
            _context.SaveChanges();
            return Ok();
        }

    }
}
