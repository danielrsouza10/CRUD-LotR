using Cod3rsGrowth.Web.Controllers.DTOs;
using Dominio.ENUMS;
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
        private readonly ServicoRaca _servicoRaca;

        public PersonagemController(ServicoPersonagem servicoPersonagem, ServicoRaca servicoRaca)
        {
            _servicoPersonagem = servicoPersonagem;
            _servicoRaca = servicoRaca;
        }

        [HttpGet("personagens")]
        public IActionResult ObterTodos([FromQuery] Filtro filtro)
        {
            var personagens = _servicoPersonagem.ObterTodos(filtro);
            var racas = _servicoRaca.ObterTodos(filtro);
            var listaDePersonagem = (from p in personagens
                                    join r in racas on p.IdRaca equals r.Id
                                    select new PersonagemDTO
                                    {
                                        Id = p.Id,
                                        Nome = p.Nome,
                                        IdRaca = r.Id,
                                        Raca = r.Nome,
                                        Profissao = p.Profissao.PegarDescricaoEnum(),
                                        Idade = p.Idade,
                                        Altura = p.Altura,
                                        EstaVivo = p.EstaVivo,
                                        DataDoCadastro = p.DataDoCadastro
                                    }).ToList();

            return Ok(listaDePersonagem);
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
            return Ok();
        }
        [HttpPut("personagem")]
        public IActionResult Editar([FromBody] Personagem personagem)
        {
            _servicoPersonagem.Editar(personagem);
            return Ok();
        }
        [HttpDelete("personagem")]
        public IActionResult Deletar([FromBody] int id)
        {
            var personagem = _servicoPersonagem.ObterPorId(id);
            if (personagem == null)
            {
                return NotFound();
            }
            _servicoPersonagem.Deletar((id));
            return Ok();
        }
    }
}
