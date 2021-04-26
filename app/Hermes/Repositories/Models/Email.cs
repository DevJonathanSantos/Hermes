using System;
using System.Collections.Generic;
using System.Text;

namespace Hermes.Repositories.Models
{
    public class Email
    {
        public Email() { }

        public Email(string de, string para, string assunto, string mensagem, string comCopia, string copiaOculta, string replyTo, string pathAnexo)
        {
            De = de;
            Para = para;
            Assunto = assunto;
            Mensagem = mensagem;
            ComCopia = comCopia;
            CopiaOculta = copiaOculta;
            ReplyTo = replyTo;
            PathAnexo = pathAnexo;
        }

        public string De { get; set; }//Precisa ser autenticado na 
        public string Para { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public string ComCopia { get; set; }
        public string CopiaOculta { get; set; }
        public string ReplyTo { get; set; }
        public string PathAnexo { get; set; }
    }
}
