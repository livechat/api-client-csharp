using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LiveChatApi
{
    class Tickets
    {
        private IApiHandler Api;

        public Tickets(IApiHandler api)
        {
            Api = api;
        }

        public async Task<string> List(Dictionary<string,string> parameters = null)
        {
            string uri = "tickets";
            string paramString = "";
            if (parameters != null && parameters.Count > 0)
            {
                foreach (var keyValuePair in parameters)
                {
                    if (paramString.Length == 0)
                    {
                        paramString += "?";
                    }
                    else
                    {
                        paramString += "&";
                    }

                    paramString += string.Format("{0}={1}", keyValuePair.Key, HttpUtility.UrlEncode(keyValuePair.Value));
                }
            }
            if (paramString.Length > 0)
            {
                uri += paramString;
            }

            return await Api.Get(uri);
        }

        public async Task<string> Get(string ticketID)
        {
            string uri = string.Format("tickets/{0}", HttpUtility.UrlEncode(ticketID));

            return await Api.Get(uri);
        }

        public async Task<string> Add(string message, string requesterMail, Dictionary<string,string> parameters = null)
        {
            string uri = "tickets";
            string content = string.Format("message={0}&requester[mail]={1}", HttpUtility.UrlEncode(message), HttpUtility.UrlEncode(requesterMail));
            if (parameters != null && parameters.Count > 0)
            {
                foreach (var keyValuePair in parameters)
                {
                    content += string.Format("&{0}={1}", keyValuePair.Key, HttpUtility.UrlEncode(keyValuePair.Value));
                }
            }

            return await Api.Post(uri, content);
        }

        public async Task<string> UpdateTags(string ticketID, string[] tags)
        {
            string uri = string.Format("tickets/{0}/tags", HttpUtility.UrlEncode(ticketID));
            string content = "";
            if (tags != null && tags.Count() > 0)
            {
                foreach (var tag in tags)
                {
                    if (content.Length > 0)
                    {
                        content += "&";
                    }
                    content += string.Format("tag[]={0}", HttpUtility.UrlEncode(tag));
                }
            }
            return await Api.Put(uri, content);
        }
    }
}
