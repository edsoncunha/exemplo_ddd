using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DDDExample.Nucleo.Infraestrutura.Log
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ExceptionLogAttribute : Attribute
    {
        public string Message { get; set; }

        public ExceptionLogAttribute(string message, string funcionalidade)
        {
            this.Message = message;
        }
    }
}
