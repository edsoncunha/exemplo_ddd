using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDExample.Nucleo.Infraestrutura.Excecoes
{
    public class VersaoSuperadaException : Exception
    {
        public VersaoSuperadaException(Exception excecaoInterna) : base(excecaoInterna.Message, excecaoInterna) { }

        public VersaoSuperadaException(string mensagem) : base(mensagem) { }
    }
}
