using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LiveChatApi
{
    class Agents
    {
        private IApiHandler Api;

        public Agents(IApiHandler api)
        {
            Api = api;
        }

        public async Task<string> List(string status = "")
        {
            string result = "";
            try
            {
                string uri = "agents";
                if (status.Length > 0)
                {
                    uri = string.Format("agents?status={0}", HttpUtility.UrlEncode(status));
                }

                result = await Api.Get(uri);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Agents.List exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> Get(string login)
        {
            string result = ""; 
            try
            {
                string uri = string.Format("agents/{0}", HttpUtility.UrlEncode(login));

                result = await Api.Get(uri);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Agents.Get exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> Add(Dictionary<string, string> props)
        {
            string result = "";
            try
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

                result = await Api.Post(uri, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Agents.Add exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> Update(string login, Dictionary<string, string> props)
        {
            string result = ""; 
            try
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

                result = await Api.Put(uri, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Agents.Update exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> ResetApiKey(string login)
        {
            string result = ""; 
            try
            {
                string uri = string.Format("agents/{0}/reset_api_key", HttpUtility.UrlEncode(login));

                result = await Api.Put(uri, "");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Agents.ResetApiKey exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> Remove(string login)
        {
            string result = ""; 
            try
            {
                string uri = string.Format("agents/{0}", HttpUtility.UrlEncode(login));

                result = await Api.Delete(uri);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Agents.Remove exception {0}", ex.ToString());
            }
            return result;
        }
    }
}
