using Dominio.Filtros;
using Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;
using Servico.Servicos;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagemController : ControllerBase
    {
        private readonly ServicoPersonagem _servicoPersonagem;
        public PersonagemController(ServicoPersonagem servicoPersonagem)
        {
            _servicoPersonagem = servicoPersonagem;
        }

        [HttpGet("personagens")]
        public IActionResult ObterTodos([FromQuery] Filtro filtro)
        {
            return Ok(_servicoPersonagem.ObterTodos(filtro));
        }
        [HttpGet("personagem/{id}")]
        public IActionResult ObterPorId([FromRoute] int id)
        {
            var personagem = _servicoPersonagem.ObterPorId(id);
            if (personagem == null)
            {
                return NotFound();
            }
            return Ok(personagem);
        }
        [HttpPost("personagem")]
        public IActionResult Criar([FromBody] Personagem personagem)
        {
            _servicoPersonagem.Criar(personagem);
            return Created(personagem.Id.ToString(), personagem);
        }
        [HttpPut("personagem")]
        public IActionResult Editar([FromBody] Personagem personagem)
        {
            _servicoPersonagem.Editar(personagem);
            return Ok();
        }

        //[HttpDelete("personagem")]
        //public IActionResult Deletar([FromBody] int id)
        //{
        //    var personagem = _servicoPersonagem.ObterPorId(id);
        //    if (personagem == null)
        //    {
        //        return NotFound();
        //    }
        //    _servicoPersonagem.Deletar((id));
        //    return Ok();
        //}
    }
}
