using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Model
{
    public class PatientProblem
    {
        public int Id { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; } 

        [ForeignKey("Problem")]
        public int ProblemId { get; set; }
        public Problem Problem { get; set; } 
    }
}
