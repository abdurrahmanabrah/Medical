using Hospital.Model;
using Medical.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationsController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public ConsultationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get Api/Consultations
        [HttpGet]
        public IEnumerable<Consultation> Get()
        {
            return _context.Consultations.ToList();
        }

        //Get Api/Consultations/2
        [HttpGet("{id}")]
        public ActionResult<Consultation> Get(int id)
        {
            var consultation = _context.Consultations.Find(id);
            if (consultation == null)
            {
                return NotFound();
            }
            return Ok(consultation);

        }

        //Post Api/Consultation
        [HttpPost]
        public IActionResult Post([FromBody] Consultation consultation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Consultations.Add(consultation);
            _context.SaveChanges();
            return CreatedAtRoute(new { id = consultation.Id }, consultation);

        }

        //Put Api/Consultation
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Consultation consultation)
        {
            var existingConsultation = _context.Consultations.Find(id);
            if (existingConsultation == null)
            {
                return NotFound();
            }

            existingConsultation.Name = consultation.Name;
            _context.SaveChanges();
            return Ok(existingConsultation);

        }

        //Delete api/Consultation
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var consultation = _context.Consultations.Find(id);
            if (consultation == null)
            {
                return NotFound();
            }

            _context.Consultations.Remove(consultation);
            _context.SaveChanges();
            return Ok();
        }
    }
}
