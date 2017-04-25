namespace DDDExample.SIGEF.Infraestrutura.Log
{
    public static class LogFactory
    {
        public static ILog GetApplicationLayerLogger()
        {
            return Log4NetProxy.GetLogger("ApplicationLayerLogger");
        }

        public static ILog GetInterfaceLayerLogger()
        {
            return Log4NetProxy.GetLogger("InterfaceLayerLogger");
        }

        public static ILog GetExternalServiceLogger()
        {
            return Log4NetProxy.GetLogger("ExternalServiceLogger");
        }
    }
}