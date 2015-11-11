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
            string result = ""; 
            try
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

                result = await Api.Get(uri);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chats.Get exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> Get(string chatID)
        {
            string result = ""; 
            try
            {
                string uri = string.Format("chats/{0}", HttpUtility.UrlEncode(chatID));

                result = await Api.Get(uri);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chats.Get chatID exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> SendTranscript(string chatID, string email)
        {
            string result = ""; 
            try
            {
                string uri = string.Format("chats/{0}/send_transcript", HttpUtility.UrlEncode(chatID));
                string content = string.Format("to={0}, HttpUtility.UrlEncode(email)");

                result = await Api.Post(uri, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chats.SendTranscript exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> Tags(string chatID, string[] tags)
        {
            string result = ""; 
            try
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

                result = await Api.Put(uri, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chats.Tags exception {0}", ex.ToString());
            }
            return result;
        }
    }
}
