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

        public async Task<string> List(string group = "")
        {
            string uri = "tags";
            if (group.Length > 0)
            {
                uri += string.Format("?group={0}", HttpUtility.UrlEncode(group));
            }

            return await Api.Get(uri);
        }

        public async Task<string> Add(string author, string tag, string group)
        {
            string uri = "tags";
            string content = string.Format("tag={0}&author={1}&group={2}", HttpUtility.UrlEncode(tag), HttpUtility.UrlEncode(author), HttpUtility.UrlEncode(group));

            return await Api.Post(uri, content);
        }

        public async Task<string> Remove(string tagID)
        {
            string uri = string.Format("tags/{0}", HttpUtility.UrlEncode(tagID));

            return await Api.Delete(uri);
        }

    }
}
