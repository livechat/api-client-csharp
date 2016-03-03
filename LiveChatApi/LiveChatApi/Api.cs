using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LiveChatApi
{
    public class Api : IApiHandler
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
            Client.DefaultRequestHeaders.UserAgent.ParseAdd("LiveChatApiClientCSharp/1.0.1");
            
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

        public async Task<string> Delete(string uri, string content = "")
        {
            HttpResponseMessage response = null;
            if (content.Length > 0) 
            {
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Content = new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded"),
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(Client.BaseAddress + uri)
                };
                response = await Client.SendAsync(request);
            }
            else
            {
                response = await Client.DeleteAsync(uri);
            }

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

        private Archives archives = null;
        public Archives Archives
        {
            get
            {
                if (archives == null)
                {
                    archives = new Archives(this);
                }
                return archives;
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

        private Chat chat = null;
        public Chat Chat
        {
            get
            {
                if (chat == null)
                {
                    chat = new Chat(this);
                }
                return chat;
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

        private Groups groups = null;
        public Groups Groups
        {
            get
            {
                if (groups == null)
                {
                    groups = new Groups(this);
                }
                return groups;
            }
        }

        private Reports reports = null;
        public Reports Reports
        {
            get
            {
                if (reports == null)
                {
                    reports = new Reports(this);
                }
                return reports;
            }
        }

        private Status status = null;
        public Status Status
        {
            get
            {
                if (status == null)
                {
                    status = new Status(this);
                }
                return status;
            }
        }

        private Tags tags = null;
        public Tags Tags
        {
            get
            {
                if (tags == null)
                {
                    tags = new Tags(this);
                }
                return tags;
            }
        }

        private Tickets tickets = null;
        public Tickets Tickets
        {
            get
            {
                if (tickets == null)
                {
                    tickets = new Tickets(this);
                }
                return tickets;
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

        private Webhooks webhooks = null;
        public Webhooks Webhooks
        {
            get
            {
                if (webhooks == null)
                {
                    webhooks = new Webhooks(this);
                }
                return webhooks;
            }
        }
    }
}
