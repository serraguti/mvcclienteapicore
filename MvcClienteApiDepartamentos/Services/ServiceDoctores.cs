using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MvcClienteApiDepartamentos.Services
{
    public class ServiceDoctores
    {
        private Uri UriApi;
        private MediaTypeWithQualityHeaderValue Header;

        public ServiceDoctores(String url)
        {
            this.UriApi = new Uri(url);
            this.Header = new MediaTypeWithQualityHeaderValue("application/json");
        }


    }
}
