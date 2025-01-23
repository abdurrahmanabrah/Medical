using Hospital.Model;
using Medical.Migrations;
using Medical.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemsController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public ProblemsController(ApplicationDbContext context)
        {
            _context = context;
        }
        //Get Api/Problems
        [HttpGet]
        public IEnumerable<Problem> Get()
        {
            return _context.Problems.ToList();
        }

        //Get Api/Problems/2
        [HttpGet("{id}")]
        public ActionResult<Problem> Get(int id)
        {
            var problem = _context.Problems.Find(id);
            if (problem == null)
            {
                return NotFound();
            }
            return Ok(problem);

        }

        //Post Api/Problems
        [HttpPost]
        public IActionResult Post([FromBody] Problem problem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Problems.Add(problem);
            _context.SaveChanges();
            return CreatedAtRoute(new { id = problem.Id }, problem);

        }

        //Put Api/Problem
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Problem problem)
        {
            var existingProblem = _context.Problems.Find(id);
            if (existingProblem == null)
            {
                return NotFound();
            }

            existingProblem.Name = problem .Name;
            _context.SaveChanges();
            return Ok(existingProblem);

        }

        //Delete api/Problems
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var problem = _context.Problems.Find(id);
            if (problem == null)
            {
                return NotFound();
            }

            _context.Problems.Remove(problem);
            _context.SaveChanges();
            return Ok();
        }



    }
}
