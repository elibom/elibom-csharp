using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elibom.APIClient.Resources
{
    class Delivery : Resource
    {
        public Delivery(RestClient client):base(client) { }

        public dynamic get(string id) 
        {
            dynamic json = this.ApiClient.get("messages/" + id, null);

            return json;
        }
    }
}
