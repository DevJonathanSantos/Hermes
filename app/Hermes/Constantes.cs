using System;
using System.Collections.Generic;
using System.Text;

namespace Hermes
{
    public class Constantes
    {
        public const string QuaryObtemEmailsNaoEnviados = "SELECT * FROM filaemailenviar WHERE DataEnvio IS NOT NULL";
    }
}
