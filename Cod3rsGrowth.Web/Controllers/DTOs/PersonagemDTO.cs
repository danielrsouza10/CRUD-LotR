using Dominio.ENUMS;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Web.Controllers.DTOs
{
    public class PersonagemDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdRaca { get; set; }
        public string Raca { get; set; }
        public string Profissao { get; set; }
        public int? Idade { get; set; }
        public float? Altura { get; set; }
        public bool EstaVivo { get; set; }
        public DateTime DataDoCadastro { get; set; }
        public PersonagemDTO()
        {
            DataDoCadastro = DateTime.Now;
        }
    }
}
