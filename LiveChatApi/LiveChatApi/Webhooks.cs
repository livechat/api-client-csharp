using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LiveChatApi
{
    public class Webhooks
    {
        private IApiHandler Api;

        public Webhooks(IApiHandler api)
        {
            Api = api;
        }

        public async Task<string> List()
        {
            string uri = "webhooks";
            
            return await Api.Get(uri);
        }

        public async Task<string> Add(string eventType, string[] dataTypes, string url)
        {
            string uri = "webhooks";
            string content = string.Format("event_type={0}&url={1}", HttpUtility.UrlEncode(eventType), HttpUtility.UrlEncode(url));
            if (dataTypes != null && dataTypes.Count() > 0)
            {
                foreach (var type in dataTypes)
                {
                    content += string.Format("&data_types[]={0}", HttpUtility.UrlEncode(type));
                }
            }

            return await Api.Post(uri, content);
        }

        public async Task<string> Remove(string webhookID)
        {
            string uri = string.Format("webhooks/{0}", HttpUtility.UrlEncode(webhookID));

            return await Api.Delete(uri);
        }
    }
}
