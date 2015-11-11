using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LiveChatApi
{
    class CannedResponses
    {
        private IApiHandler Api;

        public CannedResponses(IApiHandler api)
        {
            Api = api;
        }

        public async Task<string> List(string group = "")
        {
            string result = "";
            try
            {
                string uri = "canned_responses";
                if (group.Length > 0)
                {
                    uri = string.Format("canned_responses?group={0}", HttpUtility.UrlEncode(group));
                }

                result = await Api.Get(uri);
            }
            catch (Exception ex)
            {
                Console.WriteLine("CannedResponses.List exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> Get(string responseID)
        {
            string result = "";
            try
            {
                string uri = string.Format("canned_responses/{0}", HttpUtility.UrlEncode(responseID));

                result = await Api.Get(uri);
            }
            catch (Exception ex)
            {
                Console.WriteLine("CannedResponses.Get exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> Add(string text, string[] tags, string group = "")
        {
            string result = "";
            try
            {
                string uri = string.Format("canned_responses");
                string content = string.Format("text={0}", HttpUtility.UrlEncode(text));
                if (tags != null && tags.Count() > 0)
                {
                    foreach (var tag in tags)
                    {
                        content += string.Format("&tags[]={0}", HttpUtility.UrlEncode(tag));
                    }
                }
                if (group.Length > 0)
                {
                    content += string.Format("&group={0}", HttpUtility.UrlEncode(text));
                }

                result = await Api.Post(uri, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("CannedResponses.Add exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> Update(string responseID, string[] tags, string text = "")
        {
            string result = "";
            try
            {
                string uri = string.Format("canned_responses/{0}", HttpUtility.UrlEncode(responseID));
                string content = "";
                if (text.Length > 0)
                {
                    content = string.Format("text={0}", HttpUtility.UrlEncode(text));
                }
                if (tags != null & tags.Count() > 0)
                {
                    foreach (var tag in tags)
                    {
                        if (content.Length > 0)
                        {
                            content += "&";
                        }
                        content += string.Format("tags[]={0}", HttpUtility.UrlEncode(tag));
                    }
                }

                result = await Api.Put(uri, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("CannedResponses.Update exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> Remove(string responseID)
        {
            string result = "";
            try
            {
                string uri = string.Format("canned_responses/{0}", HttpUtility.UrlEncode(responseID));

                result = await Api.Delete(uri);
            }
            catch (Exception ex)
            {
                Console.WriteLine("CannedResponses.Remove exception {0}", ex.ToString());
            }
            return result;
        }
    }
}
