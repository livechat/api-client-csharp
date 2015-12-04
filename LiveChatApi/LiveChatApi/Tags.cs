using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LiveChatApi
{
    public class Tags
    {
        private IApiHandler Api;

        public Tags(IApiHandler api)
        {
            Api = api;
        }

        public async Task<string> List(string groupID = "")
        {
            string uri = "tags";
            if (groupID.Length > 0)
            {
                uri += string.Format("?group={0}", HttpUtility.UrlEncode(groupID));
            }

            return await Api.Get(uri);
        }

        public async Task<string> Add(string author, string tag, string groupID)
        {
            string uri = "tags";
            string content = string.Format("tag={0}&author={1}&group={2}", HttpUtility.UrlEncode(tag), HttpUtility.UrlEncode(author), HttpUtility.UrlEncode(groupID));

            return await Api.Post(uri, content);
        }

        public async Task<string> Remove(string tag, string groupID)
        {
            string uri = string.Format("tags/{0}", HttpUtility.UrlEncode(tag));
            string content = string.Format("group={0}", HttpUtility.UrlEncode(groupID));

            return await Api.Delete(uri, content);
        }

    }
}
