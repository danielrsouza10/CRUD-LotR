using Dominio.Filtros;
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
            return Ok(_servicoRaca.ObterTodos(filtro));
        }
        //[HttpGet("raca/{id}")]
        //public IActionResult ObterPorId([FromRoute] int id)
        //{
        //    var raca = _servicoRaca.ObterPorId(id);
        //    if (raca == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(raca);
        //}
        //[HttpPost("raca")]
        //public IActionResult Criar([FromBody] Raca raca) 
        //{
        //    _servicoRaca.Criar(raca);
        //    return Ok();
        //}
        //[HttpPut("raca")]
        //public IActionResult Editar([FromBody] Raca raca)
        //{
        //    _servicoRaca.Editar(raca);
        //    return Ok();
        //}

        //[HttpDelete("raca")]
        //public IActionResult Deletar([FromBody] int id)
        //{
        //    var raca = _servicoRaca.ObterPorId(id);
        //    if (raca == null)
        //    {
        //        return NotFound();
        //    }
        //    _servicoRaca.Deletar(id);
        //    return Ok();
        //}
    }
}
