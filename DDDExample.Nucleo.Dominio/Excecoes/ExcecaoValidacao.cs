using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDExample.Nucleo.Dominio.Excecoes
{
    public class ExcecaoValidacao : Exception
    {
        public List<string> CodigosErro = new List<string>();
        
        public ExcecaoValidacao(string mensagem, string codigoErro) : base(mensagem) 
        {
            CodigosErro.Add(codigoErro);
        }
    }
}
