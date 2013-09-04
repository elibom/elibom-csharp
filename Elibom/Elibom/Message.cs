using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elibom
{
    class Message : Resource
    {
        public Message(string user, string token)
            : base(user, token)
        {
        }

        public String send(string to, string text)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("destinations", to);
            data.Add("text", text);

            Client client = new Client(this.User, this.Token);
            dynamic json = client.post("messages/", data);
         
            return json["deliveryToken"];
        }

    }
}
