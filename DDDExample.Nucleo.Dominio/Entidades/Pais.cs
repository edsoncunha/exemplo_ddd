using System;
using System.Text;
using System.Collections.Generic;
using System.Web.Script.Serialization;


namespace DDDExample.Nucleo.Dominio.Entidades {
    
    public class Pais : Entidade {
        public Pais() {
            
        }

        public virtual string CodigoPais { get; set; }
        public virtual System.Nullable<int> CodigoArea { get; set; }
        public virtual string Nome { get; set; }
        public virtual string NomePreposicao { get; set; }
        public virtual string NomeOficial { get; set; }
        [ScriptIgnore]
        public virtual IList<Agrupamento> Agrupamento { get; set; }
    }
}
