using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elibom 
{
    class Schedule : Resource
    {
        public Schedule(string user, string token)
            : base(user, token)
        {
        }

        public string schedule(string to, string txt, string date) 
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("destinations", to);
            data.Add("text", txt);
            data.Add("scheduledDate", date);

            return this.schedule(data);
        }

        public string schedule(string to, string txt, string date, string campaign)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("destinations", to);
            data.Add("text", txt);
            data.Add("scheduledDate", date);
            data.Add("campaign", campaign);

            return this.schedule(data);
        }

        private string schedule(Dictionary<string, string> data)
        {
            Client client = new Client(this.User, this.Token);
            dynamic schedule = client.post("messages/", data);

            return schedule["scheduleId"];

        }

        public dynamic get(string id)
        {
            Client client = new Client(this.User, this.Token);
            dynamic schedule = client.get("schedules/" + id, null);

            return schedule;
        }

        public dynamic getAll()
        {
            Client client = new Client(this.User, this.Token);
            dynamic schedules = client.get("schedules/scheduled", null);
            return schedules;
        }

        public void unschedule(string id)
        {
            Client client = new Client(this.User, this.Token);
            client.delete("schedules/" + id, null);
        }
    }
}
