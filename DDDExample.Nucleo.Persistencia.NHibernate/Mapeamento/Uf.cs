using System;
using System.Text;
using System.Collections.Generic;


namespace DDDExample.Nucleo.Dominio.Entidades {
    
    public class Uf : Entidade {
        public Uf() {
			
        }
        public virtual string CodigoUf { get; set; }
        public virtual Pais Pais { get; set; }
        public virtual string DescricaoUf { get; set; }
    }
}
