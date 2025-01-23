using Hospital.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Medical.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Degree> Degree { get; set; }
        public DbSet<Institute> Institutes { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientProblem> PatientProblems { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<SpecialInterest> SpecialInterests { get; set; }
    }
}
