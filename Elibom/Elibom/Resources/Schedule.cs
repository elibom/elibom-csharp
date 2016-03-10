using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elibom.APIClient.Resources
{
    class Schedule : Resource
    {
        public Schedule(RestClient client):base(client) { }

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
            dynamic schedule = this.ApiClient.post("messages/", data);

            return schedule["scheduleId"];
        }

        public dynamic get(string id)
        {
            dynamic schedule = this.ApiClient.get("schedules/" + id, null);

            return schedule;
        }

        public dynamic getAll()
        {
            dynamic schedules = this.ApiClient.get("schedules/scheduled", null);
            return schedules;
        }

        public void unschedule(string id)
        {
            this.ApiClient.delete("schedules/" + id, null);
        }
    }
}
