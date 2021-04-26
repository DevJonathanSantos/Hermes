using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Interfaces
{
    public interface IEmailService
    {
        public Task EnviarEmail();
    }
}
