using Hermes.Interfaces;
using Hermes.Repositories.Models;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IConfiguration configuration;
        public async Task<List<Email>> ObterEmails()
        {
            List<Email> emails = new List<Email>()
            {
                new Email
                {
                    De="jonathanoliveira.dev@gmail.com",
                    Para="jojo.rtd1@gmail.com",
                    Assunto="Boaaaa"

                }
            };

            //using (var conexao = new MySqlConnection(configuration.GetConnectionString("MySqlConnection")))
            //{
            //    await conexao.OpenAsync();

            //    using (var command = conexao.CreateCommand())
            //    {
            //        command.CommandText = Constantes.QuaryObtemEmailsNaoEnviados;

            //        using (var reader = await command.ExecuteReaderAsync())
            //        {
            //            while (await reader.ReadAsync())
            //            {
            //                emails.Add(new Email
            //                {
            //                    De = reader.GetString("De"),
            //                    Para = reader.GetString("Para"),
            //                    Assunto = reader.GetString("Assunto"),
            //                    ComCopia = reader.GetString("ComCopia"),
            //                    CopiaOculta = reader.GetString("CopiaOculta"),
            //                    Mensagem = reader.GetString("Mensagem"),
            //                    ReplyTo = reader.GetString("ReplyTo"),
            //                    PathAnexo = reader.GetString("PathAnexo")
            //                });
            //            }
            //        }
            //    }

            //    if (conexao != null && conexao.State != System.Data.ConnectionState.Closed)
            //    {
            //        conexao.Clone();
            //    }
            //}

            return emails;
        }
    }
}
