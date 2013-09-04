using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elibom
{
    class User : Resource
    {
        public User(string user, string token)
            : base(user, token)
        {
        }

        public dynamic get(string id) 
        {
            Client client = new Client(this.User, this.Token);
            dynamic user = client.get("users/" + id, null);

            return user;
        }

        public dynamic getAll() 
        {
            Client client = new Client(this.User, this.Token);
            dynamic user = client.get("users/", null);

            return user;
        }
    }
}
