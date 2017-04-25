using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DDDExample.Nucleo.Infraestrutura.Recursos
{
    public class NetworkHelper
    {
        public string GetIP()
        {
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            IPAddress[] addr = ipEntry.AddressList;

            return addr[addr.Length - 1].ToString();

        }

        public string PostAPI<T>(string url, T data, string login, string password)
        {
            byte[] bytes = null;

            if (data.GetType() == typeof(String))
            {
                bytes = Encoding.Default.GetBytes(data.ToString());
            }
            else
            {
                var dataString = StringHelper.JsonSerializer(data);
                bytes = Encoding.Default.GetBytes(dataString);
            }

            using (var client = new WebClient { Credentials = new NetworkCredential(login, password), })
            {
                client.Headers.Add("Content-Type", "application/json");
                var response = client.UploadData(string.Format("http://{0}", url), "POST", bytes);

                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                return Encoding.Default.GetString(response);
            }
        }
    }
}
