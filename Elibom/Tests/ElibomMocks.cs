using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elibom.APIClient;
using System.Net;
using System.IO;

namespace ElibomTesting
{
    class RestClientMock : RestClient
    {

        private string requestBody;
        private Dictionary<string, Object> expectedRequest;
        private string response;

        public RestClientMock(string user, string password)
        : base(user, password)
        { }

        protected override dynamic executeRequest(HttpWebRequest request)
        {
            dynamic dataResponse = null;
            if (isValidRequest(request))
            {
                dataResponse = buildDynamic(this.response);
            }

            return dataResponse;
        }

        public void stubRequest(Dictionary<string, Object> expectedRequest, string response)
        {
            this.expectedRequest = expectedRequest;
            this.response = response;
        }

        private bool isValidRequest(HttpWebRequest request)
        {
            return isValidURL(request) && isValidMethod(request) && isValidHeaders(request) && isValidBody(request);
        }

        private bool isValidURL(HttpWebRequest request)
        {
            if (!request.RequestUri.AbsoluteUri.Equals(this.expectedRequest["url"]))
            {
                throw new Exception("Invalid URL - Expected : " + this.expectedRequest["url"] + "  URL : " + request.RequestUri.AbsoluteUri);
            }
            return true;
        }

        private bool isValidMethod(HttpWebRequest request)
        {
            if (!request.Method.Equals(this.expectedRequest["method"]))
            {
                throw new Exception("Invalidp Method - Expected : " + this.expectedRequest["method"] + "  Method : " + request.Method);
            }
            return true;
        }

        private bool isValidHeaders(HttpWebRequest request)
        {
            Dictionary<string, string> expectedHeaders = (Dictionary<string, string>)this.expectedRequest["headers"];
            foreach (KeyValuePair<string, string> header in expectedHeaders)
            {
                if (!request.Headers[header.Key].Equals(header.Value)) throw new Exception("Invalid Headers");
            }
            return true;
        }

        private bool isValidBody(WebRequest request)
        {
            if (expectedRequest.ContainsKey("body") && !expectedRequest["body"].Equals(this.requestBody))
            {
                throw new Exception("Invalid body - Expected : " + this.expectedRequest["body"] + "  Body : " + requestBody);
            }
            return true;
        }

        //Overrided to catch request body
        protected override void setJsonToRequest(string json, Stream stream)
        {
            this.requestBody = json;
        }
    }

    class ElibomClientMock : ElibomClient
    {
        public ElibomClientMock(string user, string password)
            : base(user, password)
        {
            this.ApiClient = new RestClientMock(user, password);
        }

        public void stubRequest(Dictionary<string, Object> expectedRequest, string response)
        {
            ((RestClientMock)this.ApiClient).stubRequest(expectedRequest, response);
        }
    }
}
