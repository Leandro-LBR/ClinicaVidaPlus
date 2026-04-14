using Microsoft.AspNetCore.Mvc;
using ClinicaVidaPlus.Models;
using ClinicaVidaPlus.Data;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVidaPlus.Controllers
{
    [ApiController]
    [Route("api/pacientes")]
    public class PacienteController : ControllerBase
    {
      private readonly ClinicaContext _context;

      public PacienteController(ClinicaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var pacientes = _context.Pacientes.ToList();
            return Ok(pacientes);
        }

        [HttpPost]
        public IActionResult Cadastrar(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();

            return Ok(paciente);
        }

        [HttpGet("buscar")]
        public IActionResult Buscar(string nome)
        {
            var encontrados = _context.Pacientes
            .Where(p => p.Nome.ToLower().Contains(nome.ToLower()))
            .ToList();

            return Ok(encontrados);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var paciente = _context.Pacientes.FirstOrDefault(p => p.Id == id);

            if (paciente == null)
            {
                return NotFound("Paciente não encontrado");
            }

            _context.Pacientes.Remove(paciente);
            _context.SaveChanges();

            return Ok("Paciente removido com sucesso");
        }

    }
}