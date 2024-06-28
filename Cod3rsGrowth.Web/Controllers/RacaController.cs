﻿using Dominio.Filtros;
using Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;
using Servico.Servicos;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacaController : ControllerBase
    {
        private readonly ServicoRaca _servicoRaca;
        public RacaController(ServicoRaca servicoRaca)
        {
            _servicoRaca = servicoRaca;
        }

        [HttpGet("racas")]
        public IActionResult ObterTodos([FromQuery] Filtro filtro)
        {
            try
            {
                return Ok(_servicoRaca.ObterTodos(filtro));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("racas")]
        public IActionResult Criar([FromBody] Raca raca) 
        {
            try
            {
                _servicoRaca.Criar(raca);
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
                return StatusCode(ex.HResult);
            }
        }
        [HttpPut("racas")]
        public IActionResult Editar([FromBody] Raca raca)
        {
            try
            {
                _servicoRaca.Editar(raca);
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
                return StatusCode(ex.HResult);
            }
        }

        [HttpDelete("racas")]
        public IActionResult Deletar([FromBody] int id)
        {
            try
            {
                _servicoRaca.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
