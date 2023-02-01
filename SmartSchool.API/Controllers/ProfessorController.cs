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
        public ProfessorController(SmartContext context)
        {
            _context = context;
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
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _context.Professores.FirstOrDefault(
                a => a.Nome.Contains(nome)
                );
            if (aluno == null) return BadRequest("O Professor nao foi encontrado");
            return Ok(aluno);
        }

        // api/professor
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        // api/professor/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Professor nao Encontrado");

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        // api/professor/1
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Professor nao Encontrado");

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        // api/professor/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Professor nao Encontrado");

            _context.Remove(aluno);
            _context.SaveChanges();
            return Ok();
        }
    }
}
