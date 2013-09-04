using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elibom
{
    public class Resource
    {
        public string User { get; set; }

        public string Token { get; set; }

        public Resource(string user, string token)
        {
            this.User = user;
            this.Token = token;
        }
    }
}
