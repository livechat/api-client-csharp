using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LiveChatApi
{
    class Greetings
    {
        private IApiHandler Api;

        public Greetings(IApiHandler api)
        {
            Api = api;
        }

        public async Task<string> List(string group = "")
        {
            string result = "";
            try
            {
                string uri = "greetings";
                if (group.Length > 0)
                {
                    uri += string.Format("?group={0}", HttpUtility.UrlEncode(group));
                }

                result = await Api.Get(uri);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greetings.List exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> Get(string greetingID)
        {
            string result = "";
            try
            {
                string uri = string.Format("greetings/{0}", HttpUtility.UrlEncode(greetingID));

                result = await Api.Get(uri);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greetings.Get exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> Add(string name, Dictionary<string, string>[] rules, string group = "")
        {
            string result = "";
            try
            {
                string uri = "greetings";
                string content = string.Format("name={0}", HttpUtility.UrlEncode(name));
                if (rules != null && rules.Count() > 0)
                {
                    int i = 0; 
                    foreach (var rule in rules)
                    {
                        foreach (var keyValuePair in rule)
                        {
                            content += string.Format("&rules[{0}][{1}]={2}", i, keyValuePair.Key, HttpUtility.UrlEncode(keyValuePair.Value));
                        }
                        i++;
                    }
                }
                if (group.Length > 0)
                {
                    content += string.Format("&group={0}", HttpUtility.UrlEncode(group));
                }

                result = await Api.Post(uri, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greetings.Get exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> Update(string greetingID, Dictionary<string, string> parameters)
        {
            string result = "";
            try
            {
                string uri = string.Format("greetings/{0}", HttpUtility.UrlEncode(greetingID));
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
               
                result = await Api.Put(uri, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greetings.Get exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> Remove(string greetingID)
        {
            string result = "";
            try
            {
                string uri = string.Format("greetings/{0}", HttpUtility.UrlEncode(greetingID));

                result = await Api.Delete(uri);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Goals.Remove exception {0}", ex.ToString());
            }
            return result;
        }
    }
}
