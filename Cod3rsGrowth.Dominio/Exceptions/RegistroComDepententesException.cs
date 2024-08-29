using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Exceptions
{
    public class RegistroComDepententesException : Exception
    {
        public RegistroComDepententesException(){}
        public RegistroComDepententesException(string? message) : base(message) { }
        public RegistroComDepententesException(string? message, Exception? innerException) : base(message, innerException) { } 
    }
}
