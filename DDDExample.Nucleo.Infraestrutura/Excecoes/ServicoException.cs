using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDExample.Nucleo.Infraestrutura.Excecoes
{
    public class ServicoException : Exception 
    {
        public ServicoException(Exception excecaoInterna) : base(excecaoInterna.Message, excecaoInterna) {
        
        }

        public ServicoException(string mensagem) : base(mensagem) { }
    }
}
