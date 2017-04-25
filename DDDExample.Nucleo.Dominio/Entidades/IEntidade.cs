using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDExample.Nucleo.Dominio.Entidades
{
    public interface IEntidade<T>
    {
        T Id { get; set; }
    }
}
