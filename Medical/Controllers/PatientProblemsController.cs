using Hospital.Model;
using Medical.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientProblemsController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public PatientProblemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PatientProblems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientProblem>>> GetPatientProblems()
        {
            return await _context.PatientProblems
                .Include(pp => pp.Patient)
                .Include(pp => pp.Problem)
                .ToListAsync();
        }

        // GET: api/PatientProblems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientProblem>> GetPatientProblem(int id)
        {
            var patientProblem = await _context.PatientProblems
                .Include(pp => pp.Patient)
                .Include(pp => pp.Problem)
                .FirstOrDefaultAsync(pp => pp.Id == id);

            if (patientProblem == null)
            {
                return NotFound();
            }

            return patientProblem;
        }

        // POST: api/PatientProblems
        [HttpPost]
        public async Task<ActionResult<PatientProblem>> CreatePatientProblem(PatientProblem patientProblem)
        {
            _context.PatientProblems.Add(patientProblem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPatientProblem), new { id = patientProblem.Id }, patientProblem);
        }

        // PUT: api/PatientProblems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatientProblem(int id, PatientProblem patientProblem)
        {
            if (id != patientProblem.Id)
            {
                return BadRequest();
            }

            _context.Entry(patientProblem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientProblemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/PatientProblems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientProblem(int id)
        {
            var patientProblem = await _context.PatientProblems.FindAsync(id);
            if (patientProblem == null)
            {
                return NotFound();
            }

            _context.PatientProblems.Remove(patientProblem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientProblemExists(int id)
        {
            return _context.PatientProblems.Any(pp => pp.Id == id);
        }
    }
}
