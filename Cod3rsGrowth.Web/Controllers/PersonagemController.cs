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
            try
            {
                return Ok(_servicoPersonagem.ObterTodos(filtro));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("personagem/{id}")]
        public IActionResult ObterPorId([FromRoute] int id)
        {
            try
            {
                return Ok(_servicoPersonagem.ObterPorId((id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("personagem")]
        public IActionResult Criar([FromBody]Personagem personagem) 
        {
            try
            {
                _servicoPersonagem.Criar(personagem);
                return Ok();
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Microsoft.Data.SqlClient.SqlException sqlex) 
            { 
                return BadRequest(sqlex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(Convert.ToInt32(ex.Message));
            }
        }
        [HttpPut("personagem")]
        public IActionResult Editar([FromBody]Personagem personagem)
        {
            try
            {
                _servicoPersonagem.Editar(personagem);
                return Ok();
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Microsoft.Data.SqlClient.SqlException sqlex)
            {
                return BadRequest(sqlex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(Convert.ToInt32(ex.Message));
            }
        }

        [HttpDelete("personagem")]
        public IActionResult Deletar([FromBody] int id)
        {
            try
            {
                _servicoPersonagem.Deletar((id));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
