using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LiveChatApi
{
    public class CannedResponses
    {
        private IApiHandler Api;

        public CannedResponses(IApiHandler api)
        {
            Api = api;
        }

        public async Task<string> List(string groupID = "")
        {
            string uri = "canned_responses";
            if (groupID.Length > 0)
            {
                uri += string.Format("?group={0}", HttpUtility.UrlEncode(groupID));
            }

            return await Api.Get(uri);
        }

        public async Task<string> Get(string responseID)
        {
            string uri = string.Format("canned_responses/{0}", HttpUtility.UrlEncode(responseID));

            return await Api.Get(uri);
        }

        public async Task<string> Add(string text, string[] tags, string groupID = "")
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
            if (groupID.Length > 0)
            {
                content += string.Format("&group={0}", HttpUtility.UrlEncode(text));
            }

            return await Api.Post(uri, content);
        }

        public async Task<string> Update(string responseID, string[] tags, string text = "")
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

            return await Api.Put(uri, content);
        }

        public async Task<string> Remove(string responseID)
        {
            string uri = string.Format("canned_responses/{0}", HttpUtility.UrlEncode(responseID));

            return await Api.Delete(uri);
        }
    }
}
