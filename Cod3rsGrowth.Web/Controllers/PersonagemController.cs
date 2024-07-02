using Dominio.Filtros;
using Dominio.Modelos;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Servico.CustomDetails;
using Servico.CustomExceptions;
using Servico.Servicos;
using System;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagemController : ControllerBase
    {
        private readonly ILogger<PersonagemController> _logger;
        private readonly ServicoPersonagem _servicoPersonagem;
        public PersonagemController(ServicoPersonagem servicoPersonagem, ILogger<PersonagemController> logger) 
        {
            _servicoPersonagem = servicoPersonagem;
            _logger = logger;
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
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("personagem/{id}")]
        public IActionResult ObterPorId([FromRoute] int id)
        {
                return Ok(_servicoPersonagem.ObterPorId(id));

        }
        [HttpPost("personagem")]
        public IActionResult Criar([FromBody]Personagem personagem) 
        {
            try
            {
                _servicoPersonagem.Criar(personagem);
            }
            catch (ValidationException veex)
            {
                _logger.LogError(veex.Message);
                return BadRequest();
            }
            catch (Microsoft.Data.SqlClient.SqlException sqlex) 
            {
                _logger.LogError(sqlex.Message);
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
            return Ok();
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
                return BadRequest();
            }
            catch (Microsoft.Data.SqlClient.SqlException sqlex)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
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
                return BadRequest();
            }
        }
    }
}
