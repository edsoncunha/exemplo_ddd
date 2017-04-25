using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDExample.SVA.Infraestrutura.Excecoes
{
    public class WebApiHttpException : Exception 
    {
        private System.Net.Http.HttpResponseMessage challengeMessage;

        public WebApiHttpException(Exception excecaoInterna) : base(excecaoInterna.Message, excecaoInterna) {
        
        }

        public WebApiHttpException(string mensagem) : base(mensagem) { }

        public WebApiHttpException(System.Net.Http.HttpResponseMessage challengeMessage)
        {
            // TODO: Complete member initialization
            this.challengeMessage = challengeMessage;
        }
    }
}
