using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDExample.Nucleo.Infraestrutura.Excecoes
{
    public class ValidacaoException : Exception 
    {
        public ValidacaoException(Exception excecaoInterna) : base(excecaoInterna.Message, excecaoInterna) { }

        public ValidacaoException(string mensagem) : base(mensagem) { }
    }
}
