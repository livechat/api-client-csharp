using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LiveChatApi
{
    class Goals
    {
        private IApiHandler Api;

        public Goals(IApiHandler api)
        {
            Api = api;
        }

        public async Task<string> List()
        {
            string result = "";
            try
            {
                string uri = "goals";
                
                result = await Api.Get(uri);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Goals.List exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> Get(string goalID)
        {
            string result = "";
            try
            {
                string uri = string.Format("goals/{0}", HttpUtility.UrlEncode(goalID));

                result = await Api.Get(uri);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Goals.Get exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> MarkAsSuccessful(string goalID, string visitorID)
        {
            string result = "";
            try
            {
                string uri = string.Format("goals/{0}/mark_as_successful", HttpUtility.UrlEncode(goalID));
                string content = string.Format("visitor_id={0}", HttpUtility.UrlEncode(visitorID));

                result = await Api.Post(uri, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Goals.MarkAsSuccessful exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> Add(string name, string type, Dictionary<string,string>parameters = null)
        {
            string result = "";
            try
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

                result = await Api.Post(uri, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Goals.Add exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> Update(string goalID, string name, string type, Dictionary<string, string> parameters = null)
        {
            string result = "";
            try
            {
                string uri = string.Format("goals/{0}", HttpUtility.UrlEncode(goalID));
                string content = string.Format("name={0}&type={1}", HttpUtility.UrlEncode(name), HttpUtility.UrlEncode(type));
                if (parameters != null && parameters.Count > 0)
                {
                    foreach (var keyValuePair in parameters)
                    {
                        content += string.Format("&{0}={1}", keyValuePair.Key, HttpUtility.UrlEncode(keyValuePair.Value));
                    }
                }

                result = await Api.Put(uri, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Goals.Update exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> Remove(string goalID)
        {
            string result = "";
            try
            {
                string uri = string.Format("goals/{0}", HttpUtility.UrlEncode(goalID));                

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
