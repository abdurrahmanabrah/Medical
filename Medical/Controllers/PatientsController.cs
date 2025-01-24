using Hospital.Model;
using Medical.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public PatientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get Api/Patients 
        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return _context.Patients.ToList();
        }

        //Get Api/Patients/2
        [HttpGet("{id}")]
        public ActionResult<Patient> Get(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);

        }

        //Post Api/Patient
        [HttpPost]
        public IActionResult Post([FromBody] Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return CreatedAtRoute(new { id = patient.Id }, patient);

        }

        //Put Api/Patient
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Patient patient)
        {
            var existingPatient = _context.Patients.Find(id);
            if (existingPatient == null)
            {
                return NotFound();
            }

            existingPatient.Age = patient.Age;
            _context.SaveChanges();
            return Ok(existingPatient);

        }

        //Delete api/Patient
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            _context.SaveChanges();
            return Ok();
        }

    }
}
