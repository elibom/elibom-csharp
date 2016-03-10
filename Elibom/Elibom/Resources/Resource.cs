using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elibom.APIClient
{
    public class Resource
    {
        protected RestClient ApiClient { get; set; }

        public Resource(RestClient client)
        {
            this.ApiClient = client;
        }
    }
}
