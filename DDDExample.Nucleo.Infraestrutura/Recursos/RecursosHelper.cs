using System.Net;
using System.Resources;
using System.Security.Cryptography;
using System.Text;

namespace DDDExample.Nucleo.Infraestrutura.Recursos
{
    public class RecursosHelper
    {
        private static ResourceManager CreateResourceManager()
        {
            return Recursos.Textos.ResourceManager;           
        }

        private static ResourceManager _resources;
        public static ResourceManager Resources
        {
            get
            {
                if (_resources == null)
                    _resources = CreateResourceManager();

                return _resources;
            }
        }

        
    }
}
