using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LiveChatApi
{
    public class Goals
    {
        private IApiHandler Api;

        public Goals(IApiHandler api)
        {
            Api = api;
        }

        public async Task<string> List()
        {
            string uri = "goals";

            return await Api.Get(uri);
        }

        public async Task<string> Get(string goalID)
        {
            string uri = string.Format("goals/{0}", HttpUtility.UrlEncode(goalID));

            return await Api.Get(uri);
        }

        public async Task<string> MarkAsSuccessful(string goalID, string visitorID)
        {
            string uri = string.Format("goals/{0}/mark_as_successful", HttpUtility.UrlEncode(goalID));
            string content = string.Format("visitor_id={0}", HttpUtility.UrlEncode(visitorID));

            return await Api.Post(uri, content);
        }

        public async Task<string> Add(string name, string type, Dictionary<string, string> parameters = null)
        {
            string uri = "goals";
            string content = string.Format("name={0}&type={1}", HttpUtility.UrlEncode(name), HttpUtility.UrlEncode(type));
            if (parameters != null && parameters.Count > 0)
            {
                foreach (var keyValuePair in parameters)
                {
                    content += string.Format("&{0}={1}", keyValuePair.Key, HttpUtility.UrlEncode(keyValuePair.Value));
                }
            }

            return await Api.Post(uri, content);
        }

        public async Task<string> Update(string goalID, Dictionary<string, string> parameters = null)
        {
            string uri = string.Format("goals/{0}", HttpUtility.UrlEncode(goalID));
            string content = "";
            if (parameters != null && parameters.Count > 0)
            {
                foreach (var keyValuePair in parameters)
                {
                    if (content.Length > 0)
                    {
                        content += "&";
                    }
                    content += string.Format("{0}={1}", keyValuePair.Key, HttpUtility.UrlEncode(keyValuePair.Value));
                }
            }

            return await Api.Put(uri, content);
        }

        public async Task<string> Remove(string goalID)
        {
            string uri = string.Format("goals/{0}", HttpUtility.UrlEncode(goalID));

            return await Api.Delete(uri);
        }
    }
}
