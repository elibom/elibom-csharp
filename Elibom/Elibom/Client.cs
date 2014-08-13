using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Elibom
{
    class Client : Resource
    {
        private string URL = "https://www.elibom.com/";

        public Client(string user, string token)
            : base(user, token)
        {
        }

        public dynamic get(string resource, Dictionary<string, string> data)
        {
            string uri = URL + resource;
            Console.WriteLine(uri);
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            if (data != null) {
                setJsonToRequest(dataToString(data), request.GetRequestStream());
            }

            return makeRequest(request);            
        }

        public dynamic post(string resource, Dictionary<string, string> data)
        {
            string uri = URL + resource;
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            setJsonToRequest(dataToString(data), request.GetRequestStream());

            return makeRequest(request);
        }

        public dynamic delete(string resource, Dictionary<string, string> data)
        {
            string uri = URL + resource;
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "DELETE";
            setJsonToRequest(dataToString(data), request.GetRequestStream());

            return makeRequest(request);
        }

        private dynamic makeRequest(HttpWebRequest request)
        {
            request.KeepAlive = false; 
            request.ServicePoint.Expect100Continue = false;
            setAuthorizationHeader(request);
            request.ContentType = "text/json";
            var response = (HttpWebResponse)request.GetResponse();
            string body = responseAsString(response.GetResponseStream());
            dynamic dataResponse = buildDynamic(body);

            return dataResponse;
        }

        private void setAuthorizationHeader(HttpWebRequest request)
        {
            string credentials = this.User + ":" + this.Token;
            Console.WriteLine(credentials);
            string auth = EncodeTo64(credentials);
            request.Headers["Authorization"] = "Basic " + auth;
        }

        private static string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.Encoding.UTF8.GetBytes(toEncode);
            string result = Convert.ToBase64String(toEncodeAsBytes);

            return result;
        }

        private void setJsonToRequest(string json, Stream stream)
        {
            var streamWritter = new StreamWriter(stream);
            streamWritter.Write(json);
            streamWritter.Flush();
            streamWritter.Close();
        }

        private string responseAsString(Stream stream)
        {
            var streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();
        }

        private dynamic buildDynamic(string body)
        {
            var jss = new JavaScriptSerializer();
            dynamic data = jss.Deserialize<dynamic>(body);
            return data;
        }

        private string dataToString(Dictionary<string, string> data)
        {
            StringBuilder sb = new StringBuilder();
            var jss = new JavaScriptSerializer();
            jss.Serialize(data, sb);

            return sb.ToString();
        }
    }
}
