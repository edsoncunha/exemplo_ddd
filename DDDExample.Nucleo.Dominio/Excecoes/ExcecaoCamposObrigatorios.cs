using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDDExample.Nucleo.Dominio.Excecoes
{
    public class ExcecaoCamposObrigatorios : Exception
    {
        private Dictionary<Func<object, object>, string> camposVazios;

        public ExcecaoCamposObrigatorios(Dictionary<Func<object, object>, string> camposVazios)
            : base(PrepararMensagem(camposVazios))
        {
            this.camposVazios = camposVazios;
        }

        private static string PrepararMensagem(Dictionary<Func<object, object>, string> camposVazios)
        {
            return string.Join(Environment.NewLine, camposVazios.Select(x => x.Value).ToArray());
        }


    }
}
