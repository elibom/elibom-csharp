using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elibom
{
    class Delivery : Resource
    {
        public Delivery(string user, string token)
            : base(user, token)
        {
        }

        public dynamic get(string id) 
        {
            Client client = new Client(this.User, this.Token);
            dynamic json = client.get("messages/" + id, null);

            return json;
        }
    }
}
