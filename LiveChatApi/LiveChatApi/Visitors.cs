using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LiveChatApi
{
    public class Visitors
    {
        private IApiHandler Api;

        public Visitors(IApiHandler api)
        {
            Api = api;
        }

        public async Task<string> List(Dictionary<string, string> parameters = null)
        {
            string uri = "visitors";
            if (parameters != null && parameters.Count > 0)
            {
                uri = "";
                foreach (var keyValuePair in parameters)
                {
                    if (uri.Length == 0)
                    {
                        uri = "visitors?";
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

        public async Task<string> AddCustomDetails(string visitorID, string licenseID, string token, string id, Dictionary<string, string> fields, string icon = "")
        {
            string uri = string.Format("visitors/{0}/details", HttpUtility.UrlEncode(visitorID));
            string content = string.Format("license_id={0}&token={1}&id={2}", HttpUtility.UrlEncode(licenseID), HttpUtility.UrlEncode(token), HttpUtility.UrlEncode(id));
            if (fields != null && fields.Count > 0)
            {
                int i = 0;
                foreach (var keyValuePair in fields)
                {
                    content += string.Format("&field[{0}][{1}]={2}", i, HttpUtility.UrlEncode(keyValuePair.Key), HttpUtility.UrlEncode(keyValuePair.Value));
                    i++;
                }
            }
            if (icon.Length > 0)
            {
                content += string.Format("&icon={0}", icon);
            }

            return await Api.Post(uri, content);
        }
    }
}
