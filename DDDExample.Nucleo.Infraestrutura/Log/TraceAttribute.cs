using System;
using System.Diagnostics;
using PostSharp.Aspects;

namespace DDDExample.SVA.Infraestrutura.Log
{
    /// <summary>
    /// Aspecto que, ao ser aplicado em um método, gera uma mensagem de trace antes e após sua execução.
    /// </summary>
    [Serializable]
    public class TraceAttribute : OnMethodBoundaryAspect
    {       
        public override void OnEntry(MethodExecutionArgs args)
        {
            Trace.TraceInformation("{0}.{1}: Entrada no método",
                                    args.Method.DeclaringType.FullName, args.Method.Name);
            Trace.Indent();
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            Trace.Unindent();
            Trace.TraceInformation("{0}.{1}: Método concluído sem erros",
                                    args.Method.DeclaringType.FullName, args.Method.Name);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            Trace.Unindent();
            Trace.TraceInformation("{0}.{1}: Exceção {2}",
                                    args.Method.DeclaringType.FullName, args.Method.Name,
                                    args.Exception.Message);
        }
    }
}
