﻿using System;
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
            string uri = "greetings";
            if (group.Length > 0)
            {
                uri += string.Format("?group={0}", HttpUtility.UrlEncode(group));
            }

            return await Api.Get(uri);
        }

        public async Task<string> Get(string greetingID)
        {
            string uri = string.Format("greetings/{0}", HttpUtility.UrlEncode(greetingID));

            return await Api.Get(uri);
        }

        public async Task<string> Add(string name, Dictionary<string, string>[] rules, Dictionary<string, string>[] funnelRules, string group = "")
        {
            string uri = "greetings";
            string content = string.Format("name={0}", HttpUtility.UrlEncode(name));
            int i = 0; 
            if (rules != null && rules.Count() > 0)
            {
                foreach (var rule in rules)
                {
                    foreach (var keyValuePair in rule)
                    {
                        content += string.Format("&rules[{0}][{1}]={2}", i, keyValuePair.Key, HttpUtility.UrlEncode(keyValuePair.Value));
                    }
                    i++;
                }
            }
            if (funnelRules != null && funnelRules.Count() > 0)
            {
                foreach (var rule in funnelRules)
                {
                    if (rule.Count > 0)
                    {
                        int j = 0;
                        content += string.Format("&rules[{0}][type]=url_funnel", i);
                        foreach (var keyValuePair in rule)
                        {
                            content += string.Format("&rules[{0}][urls][{1}][url]={2}", i, j, HttpUtility.UrlEncode(keyValuePair.Key));
                            content += string.Format("&rules[{0}][urls][{1}][operator]={2}", i, j, HttpUtility.UrlEncode(keyValuePair.Value));
                            j++;
                        }
                        i++;
                    }
                }
            }
            if (group.Length > 0)
            {
                content += string.Format("&group={0}", HttpUtility.UrlEncode(group));
            }

            return await Api.Post(uri, content);
        }

        public async Task<string> Update(string greetingID, Dictionary<string, string> parameters)
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

            return await Api.Put(uri, content);
        }

        public async Task<string> Remove(string greetingID)
        {
            string uri = string.Format("greetings/{0}", HttpUtility.UrlEncode(greetingID));

            return await Api.Delete(uri);
        }
    }
}
