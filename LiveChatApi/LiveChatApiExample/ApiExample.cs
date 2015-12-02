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
            Console.WriteLine("Get greetings");
            string result = await Api.Greetings.List();
            Console.WriteLine(result);

            Console.ReadLine();
            
            Console.WriteLine("Get greeting");
            result = await Api.Greetings.Get("7661");
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Add greeting");
            Dictionary<string, string>[] rules = { new Dictionary<string, string>(), new Dictionary<string, string>() };
            rules[0].Add("type", "visit_time_page");
            rules[0].Add("value", "15");
            rules[0].Add("operator", "greater_than");
            rules[1].Add("type", "custom_variable");
            rules[1].Add("variable_name", "my_custom_var");
            rules[1].Add("variable_value", "var_value");
            rules[1].Add("operator", "contains");
            Dictionary<string, string>[] funnelRules = { new Dictionary<string, string>() };
            funnelRules[0].Add("mystore.com/shoes", "equals");
            funnelRules[0].Add("cart", "contains");
            result = await Api.Greetings.Add("my_invitation", rules, funnelRules);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Update greeting");
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("active","1");
            result = await Api.Greetings.Update("7661", parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Remove greeting");
            result = await Api.Greetings.Remove("7661");
            Console.WriteLine(result);

            Console.WriteLine("");
        }

        public async Task GroupsTest()
        {
            Console.WriteLine("Get groups"); 
            string result = await Api.Groups.List();
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Get group");
            result = await Api.Groups.Get("0");
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Add group");
            string[] agents = { "k.gorski+2014102701@livechatinc.com" };
            result = await Api.Groups.Add("new_group", agents);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Update group");
            string[] agents2 = { "k.gorski+2014102701@livechatinc.com" };
            result = await Api.Groups.Update("1", agents2);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Remove group");
            result = await Api.Groups.Remove("2");
            Console.WriteLine(result);

            Console.WriteLine("");
        }

        public async Task ReportsTest()
        {
            Console.WriteLine("Get total chats"); 
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string result = await Api.Reports.TotalChats(parameters);
            Console.WriteLine(result);

            Console.WriteLine("");
        }

        public async Task StatusTest()
        {
            Console.WriteLine("Get status"); 
            string result = await Api.Status.Get();
            Console.WriteLine(result);

            Console.WriteLine("");
        }

        public async Task TagsTest()
        {
            Console.WriteLine("Get tags"); 
            string result = await Api.Tags.List();
            Console.WriteLine(result);

            Console.WriteLine("");
        }

        public async Task TicketsTest()
        {
            Console.WriteLine("Get tickets"); 
            string result = await Api.Tickets.List();
            Console.WriteLine(result);

            Console.WriteLine("");
        }

        public async Task VisitorsTest()
        {
            Console.WriteLine("Get visitors"); 
            string result = await Api.Visitors.List();
            Console.WriteLine(result);

            Console.WriteLine("");
        }

        public async Task WebhooksTest()
        {
            Console.WriteLine("Get webhooks"); 
            string result = await Api.Webhooks.List();
            Console.WriteLine(result);

            Console.WriteLine("");
        }
    }
}
