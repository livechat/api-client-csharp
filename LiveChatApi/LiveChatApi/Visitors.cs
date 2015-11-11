using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LiveChatApi
{
    class Visitors
    {
        private IApiHandler Api;

        public Visitors(IApiHandler api)
        {
            Api = api;
        }

        public async Task<string> List(Dictionary<string,string> parameters = null)
        {
            string result = "";
            try
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

                result = await Api.Get(uri);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Visitors.List exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> AddCustomDetails(string visitorID, string licenseID, string token, string id, Dictionary<string, string> fields, string icon = "")
        {
            string result = ""; 
            try
            {
                string uri = string.Format("visitors/{0}/details", HttpUtility.UrlEncode(visitorID));
                string content = string.Format("license_id={0}&token={1}&id={2}", HttpUtility.UrlEncode(licenseID), HttpUtility.UrlEncode(token), HttpUtility.UrlEncode(id));
                int i = 0;
                if (fields != null && fields.Count > 0)
                {
                    foreach (var keyValuePair in fields)
                    {
                        content += string.Format("&field[{0}][{1}]={2}", i, HttpUtility.UrlEncode(keyValuePair.Key), HttpUtility.UrlEncode(keyValuePair.Value));
                    }
                }
                if (icon.Length > 0)
                {
                    content += string.Format("&icon={0}", icon);
                }

                result = await Api.Post(uri, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Visitors.AddCustomDetails exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> StartChat(string visitorID, string licenseID, string welcomeMessage, Dictionary<string, string> parameters = null)
        {
            string result = ""; 
            try
            {
                string uri = string.Format("visitors/{0}/chat/start", HttpUtility.UrlEncode(visitorID));
                string content = string.Format("license_id={0}&welcome_message={1}", HttpUtility.UrlEncode(licenseID), HttpUtility.UrlEncode(welcomeMessage));
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
                Console.WriteLine("Visitors.StartChat exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> GetPendingMessages(string visitorID, string licenseID, string sessionID, string lastMessageID = "")
        {
            string result = ""; 
            try
            {
                string uri = string.Format("visitors/{0}/chat/get_pending_messages?licence_id={1}&secured_session_id={2}", HttpUtility.UrlEncode(visitorID), HttpUtility.UrlEncode(licenseID), HttpUtility.UrlEncode(sessionID));
                if (lastMessageID.Length > 0)
                {
                    uri += string.Format("&last_message_id={0}", lastMessageID);
                }

                result = await Api.Get(uri);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Visitors.GetPendingMessages exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> SendMessage(string visitorID, string licenseID, string sessionID, string message)
        {
            string result = ""; 
            try
            {
                string uri = string.Format("visitors/{0}/chat/send_message", HttpUtility.UrlEncode(visitorID));
                string content = string.Format("license_id={0}&secured_session_id={1}&message={2}", HttpUtility.UrlEncode(licenseID), HttpUtility.UrlEncode(sessionID), HttpUtility.UrlEncode(message));

                result = await Api.Post(uri, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Visitors.SendMessage exception {0}", ex.ToString());
            }
            return result;
        }

        public async Task<string> CloseChat(string visitorID, string licenseID, string sessionID)
        {
            string result = ""; 
            try
            {
                string uri = string.Format("visitors/{0}/chat/close", HttpUtility.UrlEncode(visitorID));
                string content = string.Format("license_id={0}&secured_session_id={1}", HttpUtility.UrlEncode(licenseID), HttpUtility.UrlEncode(sessionID));

                result = await Api.Post(uri, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Visitors.CloseChat exception {0}", ex.ToString());
            }
            return result;
        }
    }
}
