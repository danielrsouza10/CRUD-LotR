using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes
{
    public class TesteBase : IDisposable
    {
        protected ServiceProvider _serviceProvider;

        public TesteBase(ServiceProvider ServiceProvider)
        {
            _serviceProvider = ServiceProvider;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
