using Hermes.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Interfaces
{
   public interface IEmailRepository
    {
        public Task<List<Email>> ObterEmails();
    }
}
