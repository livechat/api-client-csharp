using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveChatApiExample
{
    public class ApiExample
    {
        LiveChatApi.Api Api;

        public ApiExample()
        {
            Api = new LiveChatApi.Api("k.gorski+2014102701@livechatinc.com", "32951c1f63624fa94cf5320142d85842");
        }

        public void Start()
        {
            do
            {
                DisplayMenu();
                string input = Console.ReadLine();
                Console.WriteLine("");

                try
                {
                    if (input == "1")
                    {
                        AgentsTest().Wait();
                    }
                    else if (input == "2")
                    {
                        CannedResponsesTest().Wait();
                    }
                    else if (input == "3")
                    {
                        ChatsTest().Wait();
                    }
                    else if (input == "4")
                    {
                        GoalsTest().Wait();
                    }
                    else if (input == "5")
                    {
                        GreetingsTest().Wait();
                    }
                    else if (input == "6")
                    {
                        GroupsTest().Wait();
                    }
                    else if (input == "7")
                    {
                        ReportsTest().Wait();
                    }
                    else if (input == "8")
                    {
                        StatusTest().Wait();
                    }
                    else if (input == "9")
                    {
                        TagsTest().Wait();
                    }
                    else if (input == "10")
                    {
                        TicketsTest().Wait();
                    }
                    else if (input == "11")
                    {
                        VisitorsTest().Wait();
                    }
                    else if (input == "12")
                    {
                        WebhooksTest().Wait();
                    }
                    else if (input == "exit" || input == "quit")
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception {0}", ex.ToString());
                }
            }
            while (true);
        }

        public void DisplayMenu()
        {
            Console.WriteLine("1. Agents");
            Console.WriteLine("2. Canned responses");
            Console.WriteLine("3. Chats");
            Console.WriteLine("4. Goals");
            Console.WriteLine("5. Greetings");
            Console.WriteLine("6. Groups");
            Console.WriteLine("7. Reports");
            Console.WriteLine("8. Status");
            Console.WriteLine("9. Tags");
            Console.WriteLine("10. Tickets");
            Console.WriteLine("11. Visitors");
            Console.WriteLine("12. Webhooks");
        }

        public async Task AgentsTest()
        {
            Console.WriteLine("List all agents"); 
            string result = await Api.Agents.List();
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Get agent");
            result = await Api.Agents.Get("k.gorski+2014102701@livechatinc.com");
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Add agent"); 
            Dictionary<string, string> props = new Dictionary<string, string>();
            props.Add("login", "k.gorski+2015103102@livechatinc.com");
            props.Add("name", "John");

            result = await Api.Agents.Add(props);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Update agent"); 
            props.Clear();
            props.Add("login_status", "not accepting chats");
            props.Add("max_chats_count", "2");

            result = await Api.Agents.Update("k.gorski+2015103102@livechatinc.com", props);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Reset Api key");
            result = await Api.Agents.ResetApiKey("k.gorski+2015103102@livechatinc.com");
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Delete agent");
            result = await Api.Agents.Remove("k.gorski+2015103102@livechatinc.com");
            Console.WriteLine(result);

            Console.WriteLine("");
        }

        public async Task CannedResponsesTest()
        {
            Console.WriteLine("List all canned responses");
            string result = await Api.CannedResponses.List();
            Console.WriteLine(result);
            
            Console.ReadLine();

            Console.WriteLine("Get canned response");
            result = await Api.CannedResponses.Get("18051");
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Add canned response");
            string[] tags = {"tag1", "tag2"};
            result = await Api.CannedResponses.Add("text", tags);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Update canned response");
            string[] tags2 = { "tag3", "tag4" };
            result = await Api.CannedResponses.Update("30131", tags2);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Delete canned response");
            result = await Api.CannedResponses.Update("30131", tags2);
            Console.WriteLine(result);
            
            Console.WriteLine("");
        }

        public async Task ChatsTest()
        {
            Console.WriteLine("Get chats");
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("date_from", "2015-10-01");
            parameters.Add("query", "test");
            string result = await Api.Chats.Get(parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Get chat");
            result = await Api.Chats.Get("NXBE94NZ10");
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Send chat transcript");
            result = await Api.Chats.SendTranscript("NXBE94NZ10", "k.gorski@livechatinc.com");
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Update chat tags");
            string[] tags = { "sales", "complaint" };
            result = await Api.Chats.Tags("NXBE94NZ10", tags);
            Console.WriteLine(result);

            Console.WriteLine("");
        }

        public async Task GoalsTest()
        {
            Console.WriteLine("Get goals");
            string result = await Api.Goals.List();
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Get goal");
            result = await Api.Goals.Get("7601");
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Mark goal as successful");
            result = await Api.Goals.MarkAsSuccessful("7601", "visitor1");
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Add goal");
            result = await Api.Goals.Add("new_goal", "api");
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Update goal"); 
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("name", "purchase_paused");
            parameters.Add("active", "0");
            result = await Api.Goals.Update("7601", parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Remove goal");
            result = await Api.Goals.Remove("7601");
            Console.WriteLine(result);

            Console.WriteLine("");
        }

        public async Task GreetingsTest()
        {
            string greetings = await Api.Greetings.List();
            Console.WriteLine("Greetings: {0}", greetings);

            Console.WriteLine("");
        }

        public async Task GroupsTest()
        {
            string groups = await Api.Groups.List();
            Console.WriteLine("Groups: {0}", groups);

            Console.WriteLine("");
        }

        public async Task ReportsTest()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string report = await Api.Reports.TotalChats(parameters);
            Console.WriteLine("Report: {0}", report);

            Console.WriteLine("");
        }

        public async Task StatusTest()
        {
            string status = await Api.Status.Get();
            Console.WriteLine("Status: {0}", status);

            Console.WriteLine("");
        }

        public async Task TagsTest()
        {
            string tags = await Api.Tags.List();
            Console.WriteLine("Tags: {0}", tags);

            Console.WriteLine("");
        }

        public async Task TicketsTest()
        {
            string tickets = await Api.Tickets.List();
            Console.WriteLine("Tickets: {0}", tickets);

            Console.WriteLine("");
        }

        public async Task VisitorsTest()
        {
            string visitors = await Api.Visitors.List();
            Console.WriteLine("Visitors: {0}", visitors);

            Console.WriteLine("");
        }

        public async Task WebhooksTest()
        {
            string webhooks = await Api.Webhooks.List();
            Console.WriteLine("Webhooks: {0}", webhooks);

            Console.WriteLine("");
        }
    }
}
