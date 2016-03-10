using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Elibom.APIClient
{
    public class RestClient
    {
        private string URL = "https://www.elibom.com/";

        private string version = "csharp-1.0.6";

        private string User;

        private string Token;

        public RestClient(string user, string token)
        {
            this.User = user;
            this.Token = token;
        }

        public dynamic get(string resource, Dictionary<string, string> data)
        {
            HttpWebRequest request = createRequest(resource, "GET", data);
            return executeRequest(request);            
        }

        public dynamic post(string resource, Dictionary<string, string> data)
        {
            HttpWebRequest request = createRequest(resource, "POST", data);
            return executeRequest(request);
        }

        public dynamic delete(string resource, Dictionary<string, string> data)
        {
            HttpWebRequest request = createRequest(resource, "DELETE", data);
            return executeRequest(request);
        }

        private HttpWebRequest createRequest(string resource, string method, Dictionary<string, string> data)
        {
            string uri = URL + resource;
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = method;
            request.KeepAlive = false;
            request.ServicePoint.Expect100Continue = false;
            setAuthorizationHeader(request);
            request.ContentType = "text/json";
            if (data != null)
            {
                setJsonToRequest(dataToString(data), request.GetRequestStream());
            }

            return request;
        }

        protected void setAuthorizationHeader(HttpWebRequest request)
        {
            string credentials = this.User + ":" + this.Token;
            string auth = EncodeTo64(credentials);
            request.Headers["Authorization"] = "Basic " + auth;
            request.Headers["X-API-Source"] = this.version; 
        }

        protected static string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.Encoding.UTF8.GetBytes(toEncode);
            string result = Convert.ToBase64String(toEncodeAsBytes);

            return result;
        }

        protected virtual void setJsonToRequest(string json, Stream stream)
        {
            var streamWritter = new StreamWriter(stream);
            streamWritter.Write(json);
            streamWritter.Flush();
            streamWritter.Close();
        }

        protected string responseAsString(Stream stream)
        {
            var streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();
        }

        protected dynamic buildDynamic(string body)
        {
            var jss = new JavaScriptSerializer();
            dynamic data = jss.Deserialize<dynamic>(body);
            return data;
        }

        protected string dataToString(Dictionary<string, string> data)
        {
            StringBuilder sb = new StringBuilder();
            var jss = new JavaScriptSerializer();
            jss.Serialize(data, sb);

            return sb.ToString();
        }

        protected virtual dynamic executeRequest(HttpWebRequest request)
        {
            var response = (HttpWebResponse)request.GetResponse();
            string body = responseAsString(response.GetResponseStream());
            dynamic dataResponse = buildDynamic(body);

            return dataResponse;
        }
    }
}
