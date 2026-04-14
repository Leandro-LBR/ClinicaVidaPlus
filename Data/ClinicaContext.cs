using Microsoft.EntityFrameworkCore;
using ClinicaVidaPlus.Models;

namespace ClinicaVidaPlus.Data
{
    public class ClinicaContext : DbContext
    {
        public ClinicaContext(DbContextOptions<ClinicaContext> options) : base(options){}
        public DbSet<Paciente> Pacientes {get; set;}
    }
}