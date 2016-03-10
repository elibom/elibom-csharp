using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elibom.APIClient.Resources
{
    class User : Resource
    {
        public User(RestClient client):base(client) { }

        public dynamic get(string id) 
        {
            dynamic user = this.ApiClient.get("users/" + id, null);

            return user;
        }

        public dynamic getAll() 
        {
            dynamic user = this.ApiClient.get("users/", null);

            return user;
        }
    }
}
