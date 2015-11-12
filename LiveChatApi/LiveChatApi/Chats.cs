using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LiveChatApi
{
    class Chats
    {
        private IApiHandler Api;

        public Chats(IApiHandler api)
        {
            Api = api;
        }

        public async Task<string> Get(Dictionary<string, string> parameters)
        {
            string uri = "";
            if (parameters != null && parameters.Count > 0)
            {
                foreach (var keyValuePair in parameters)
                {
                    if (uri.Length == 0)
                    {
                        uri = "chats?";
                    }
                    else
                    {
                        uri += "&";
                    }
                    uri += string.Format("{0}={1}", keyValuePair.Key, HttpUtility.UrlEncode(keyValuePair.Value));
                }
            }

            return await Api.Get(uri);
        }

        public async Task<string> Get(string chatID)
        {
            string uri = string.Format("chats/{0}", HttpUtility.UrlEncode(chatID));

            return await Api.Get(uri);
        }

        public async Task<string> SendTranscript(string chatID, string email)
        {
            string uri = string.Format("chats/{0}/send_transcript", HttpUtility.UrlEncode(chatID));
            string content = string.Format("to={0}, HttpUtility.UrlEncode(email)");

            return await Api.Post(uri, content);
        }

        public async Task<string> Tags(string chatID, string[] tags)
        {
            string uri = string.Format("chats/{0}/tags", HttpUtility.UrlEncode(chatID));
            string content = "";
            if (tags != null && tags.Count() > 0)
            {
                foreach (var tag in tags)
                {
                    if (content.Length > 0)
                    {
                        content += "&";
                    }
                    content += string.Format("tag[]={1}", HttpUtility.UrlEncode(tag));
                }
            }

            return await Api.Put(uri, content);
        }
    }
}
