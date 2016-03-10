using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elibom.APIClient.Resources
{
    class Account : Resource
    {
        public Account(RestClient client):base(client) { }

        public dynamic get()
        {
            dynamic json = this.ApiClient.get("account", null);

            return json;
        }
    }
}
