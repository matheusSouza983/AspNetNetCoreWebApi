using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System.Linq;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;

        public readonly IRepository _repo;

        public ProfessorController(SmartContext context, IRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        // api/professor
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        // api/professor/byId/1
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O Professor nao foi encontrato");
            return Ok(aluno);
        }

        // api/professor
        [HttpGet("byName")]
        public IActionResult GetByName(string nome)
        {
            var professor = _context.Professores.FirstOrDefault(
                a => a.Nome.Contains(nome)
                );
            if (professor == null) return BadRequest("O Professor nao foi encontrado");
            return Ok(professor);
        }

        // api/professor
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor nao Cadastrado");
        }

        // api/professor/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var alu = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Professor nao Encontrado");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        // api/professor/1
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var alu = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Professor nao Encontrado");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        // api/professor/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (professor == null) return BadRequest("Professor nao Encontrado");

            _context.Remove(professor);
            _context.SaveChanges();
            return Ok();
        }
    }
}
