using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elibom
{
    class Account : Resource
    {
        public Account(string user, string token)
            : base(user, token)
        {
        }

        public dynamic get()
        {
            Client client = new Client(this.User, this.Token);
            dynamic json = client.get("account", null);

            return json;
        }
    }
}
