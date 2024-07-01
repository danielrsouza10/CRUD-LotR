using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.CustomExceptions
{
    public class RacaCustomExceptions : Exception
    {
        public string Type { get; set; }
        public string Detail { get; set; }
        public string Title { get; set; }
        public string Instance { get; set; }

        public RacaCustomExceptions(string instance)
        {
            Title = "Exceção de Produto Customizada";
            Detail = "Ocorreu umerro inesperado ao tentar obter a raça.";
            Type = "produto-custom-exception";
            Instance = instance;
        }
    }
}
