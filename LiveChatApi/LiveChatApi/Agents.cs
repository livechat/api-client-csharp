using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LiveChatApi
{
    public class Agents
    {
        private IApiHandler Api;

        public Agents(IApiHandler api)
        {
            Api = api;
        }

        public async Task<string> List(string status = "")
        {
            string uri = "agents";
            if (status.Length > 0)
            {
                uri += string.Format("?status={0}", HttpUtility.UrlEncode(status));
            }

            return await Api.Get(uri);
        }

        public async Task<string> Get(string login)
        {
            string uri = string.Format("agents/{0}", HttpUtility.UrlEncode(login));

            return await Api.Get(uri);
        }

        public async Task<string> Add(Dictionary<string, string> props)
        {
            string uri = "agents";
            string content = "";
            if (props != null && props.Count > 0)
            {
                foreach (var keyValuePair in props)
                {
                    if (content.Length > 0)
                    {
                        content += "&";
                    }
                    content += string.Format("{0}={1}", keyValuePair.Key, HttpUtility.UrlEncode(keyValuePair.Value));
                }
            }

            return await Api.Post(uri, content);
        }

        public async Task<string> Update(string login, Dictionary<string, string> props)
        {
            string uri = string.Format("agents/{0}", HttpUtility.UrlEncode(login));
            string content = "";
            if (props != null && props.Count > 0)
            {
                foreach (var keyValuePair in props)
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

        public async Task<string> ResetApiKey(string login)
        {
            string uri = string.Format("agents/{0}/reset_api_key", HttpUtility.UrlEncode(login));

            return await Api.Post(uri, "");
        }

        public async Task<string> Remove(string login)
        {
            string uri = string.Format("agents/{0}", HttpUtility.UrlEncode(login));

            return await Api.Delete(uri);
        }
    }
}
