using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LiveChatApi
{
    public class Status
    {
        private IApiHandler Api;

        public Status(IApiHandler api)
        {
            Api = api;
        }

        public async Task<string> List(string group = "")
        {
            string uri = "status";
            if (group.Length > 0)
            {
                uri += string.Format("/{0}", HttpUtility.UrlEncode(group));
            }

            return await Api.Get(uri);
        }
    }
}
