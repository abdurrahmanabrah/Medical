using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Model
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Degree")]
        public int DegreeId { get; set; }
        public Degree Degree { get; set; } 

        [ForeignKey("Institute")]
        public int InstituteId { get; set; }
        public Institute Institute { get; set; } 

        public string BMDCNO { get; set; }

        [ForeignKey("Consultation")]
        public int ConsultationId { get; set; }
        public Consultation Consultation { get; set; } 

        [ForeignKey("SpecialInterest")]
        public int SpecialInterestId { get; set; }
        public SpecialInterest SpecialInterest { get; set; } 
    }
}
