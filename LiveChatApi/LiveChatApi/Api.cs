using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LiveChatApi
{
    class Api : IApiHandler
    {
        private HttpClient Client;
        
        public Api(string login, string apiKey)
        {
            Client = new HttpClient()
            {
                BaseAddress = new Uri(Constants.ApiBaseAddress)
            };
            Client.DefaultRequestHeaders.Add("x-api-version", "2");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            string credentials = string.Format("{0}:{1}", login, apiKey);
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(credentials)));           
        }

        public async Task<string> Get(string uri)
        {
            HttpResponseMessage response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                Console.WriteLine("Error: {1} - {0}", (int)response.StatusCode, response.ReasonPhrase);
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response: {0}", responseContent);
            }
            return "";
        }

        public async Task<string> Post(string uri, string content)
        {
            HttpResponseMessage response = await Client.PostAsync(uri, new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded"));
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                Console.WriteLine("Error: {1} - {0}", (int)response.StatusCode, response.ReasonPhrase);
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response: {0}", responseContent);
            }
            return "";
        }

        public async Task<string> Put(string uri, string content)
        {
            HttpResponseMessage response = await Client.PutAsync(uri, new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded"));
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                Console.WriteLine("Error: {1} - {0}", (int)response.StatusCode, response.ReasonPhrase);
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response: {0}", responseContent);
            }
            return "";
        }

        public async Task<string> Delete(string uri)
        {
            HttpResponseMessage response = await Client.DeleteAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                Console.WriteLine("Error: {1} - {0}", (int)response.StatusCode, response.ReasonPhrase);
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response: {0}", responseContent);
            }
            return "";
        }

        private Agents agents = null;
        public Agents Agents 
        {
            get
            {
                if (agents == null)
                {
                    agents = new Agents(this);
                }
                return agents;
            }
        }

        private Chats chats = null;
        public Chats Chats
        {
            get
            {
                if (chats == null)
                {
                    chats = new Chats(this);
                }
                return chats;
            }
        }

        private Visitors visitors = null;
        public Visitors Visitors
        {
            get
            {
                if (visitors == null)
                {
                    visitors = new Visitors(this);
                }
                return visitors;
            }
        } 

        private CannedResponses cannedResponses = null;
        public CannedResponses CannedResponses
        {
            get
            {
                if (cannedResponses == null)
                {
                    cannedResponses = new CannedResponses(this);
                }
                return cannedResponses;
            }
        }

        private Goals goals = null;
        public Goals Goals
        {
            get
            {
                if (goals == null)
                {
                    goals = new Goals(this);
                }
                return goals;
            }
        }

        private Greetings greetings = null;
        public Greetings Greetings
        {
            get
            {
                if (greetings == null)
                {
                    greetings = new Greetings(this);
                }
                return greetings;
            }
        }
    }
}
