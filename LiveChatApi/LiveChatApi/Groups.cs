using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LiveChatApi
{
    public class Groups
    {
        private IApiHandler Api;

        public Groups(IApiHandler api)
        {
            Api = api;
        }

        public async Task<string> List()
        {
            string uri = "groups";
            
            return await Api.Get(uri);
        }

        public async Task<string> Get(string groupID)
        {
            string uri = string.Format("groups/{0}", groupID);

            return await Api.Get(uri);
        }

        public async Task<string> Add(string name, string[] agents, string language = "")
        {
            string uri = "groups";
            string content = string.Format("name={0}", HttpUtility.UrlEncode(name));
            if (agents != null && agents.Count() > 0)
            {
                int i = 0;
                foreach (var agent in agents)
                {
                    content += string.Format("&agent[{0}]={1}", i, HttpUtility.UrlEncode(agent));
                }
            }
            if (language.Length > 0)
            {
                content += string.Format("&language={0}", HttpUtility.UrlEncode(language));
            }

            return await Api.Post(uri, content);
        }

        public async Task<string> Update(string groupID, string[] agents, string name = "", string language = "")
        {
            string uri = string.Format("groups/{0}", groupID);
            string content = "";
            if (agents != null && agents.Count() > 0)
            {
                int i = 0;
                foreach (var agent in agents)
                {
                    if (content.Length > 0)
                    {
                        content += "&";
                    }
                    content += string.Format("agent[{0}]={1}", i, HttpUtility.UrlEncode(agent));
                }
            }
            if (name.Length > 0)
            {
                if (content.Length > 0)
                {
                    content += "&";
                } 
                content += string.Format("name={0}", HttpUtility.UrlEncode(name));
            }
            if (language.Length > 0)
            {
                if (content.Length > 0)
                {
                    content += "&";
                } 
                content += string.Format("language={0}", HttpUtility.UrlEncode(language));
            }

            return await Api.Post(uri, content);
        }

        public async Task<string> Remove(string groupID)
        {
            string uri = string.Format("groups/{0}", groupID);

            return await Api.Delete(uri);
        }
    }
}
