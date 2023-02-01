using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno()
            {
                Id= 1,
                Nome= "Marcos",
                Sobrenome= "Almeida",
                Telefone= "249871yoqiw"
            },
            new Aluno(){
                Id= 2,
                Nome= "Marta",
                Sobrenome= "Kent",
                Telefone= "shbssaedgbas"
            },
            new Aluno(){
                Id= 3,
                Nome= "Laura",
                Sobrenome= "Maria",
                Telefone= "ghbasba"
            }
        };

        public AlunoController() { }

        // api/aluno
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        // api/aluno/byId/1
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O aluno nao foi encontrato");
            return Ok(aluno);
        }

        // api/aluno
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(
                a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome)
                );
            if (aluno == null) return BadRequest("O aluno nao foi encontrado");
            return Ok(aluno);
        }

        // api/aluno
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        // api/aluno/1
        [HttpPut("{id}")]
        public IActionResult Put(int Id, Aluno aluno)
        {
            return Ok(aluno);
        }

        // api/aluno/1
        [HttpPatch("{id}")]
        public IActionResult Patch(int Id, Aluno aluno)
        {
            return Ok(aluno);
        }

        // api/aluno/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            return Ok();
        }
    }
}
