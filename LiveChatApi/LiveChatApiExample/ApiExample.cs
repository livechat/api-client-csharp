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
                        ArchivesTest().Wait();
                    }
                    else if (input == "3")
                    {
                        CannedResponsesTest().Wait();
                    }
                    else if (input == "4")
                    {
                        ChatTest().Wait();
                    }
                    else if (input == "5")
                    {
                        GoalsTest().Wait();
                    }
                    else if (input == "6")
                    {
                        GreetingsTest().Wait();
                    }
                    else if (input == "7")
                    {
                        GroupsTest().Wait();
                    }
                    else if (input == "8")
                    {
                        ReportsTest().Wait();
                    }
                    else if (input == "9")
                    {
                        StatusTest().Wait();
                    }
                    else if (input == "10")
                    {
                        TagsTest().Wait();
                    }
                    else if (input == "11")
                    {
                        TicketsTest().Wait();
                    }
                    else if (input == "12")
                    {
                        VisitorsTest().Wait();
                    }
                    else if (input == "13")
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
            Console.WriteLine("2. Archives");
            Console.WriteLine("3. Canned responses");
            Console.WriteLine("4. Chat");
            Console.WriteLine("5. Goals");
            Console.WriteLine("6. Greetings");
            Console.WriteLine("7. Groups");
            Console.WriteLine("8. Reports");
            Console.WriteLine("9. Status");
            Console.WriteLine("10. Tags");
            Console.WriteLine("11. Tickets");
            Console.WriteLine("12. Visitors");
            Console.WriteLine("13. Webhooks");
        }

        public async Task AgentsTest()
        {
            Console.WriteLine("List all agents"); 
            string result = await Api.Agents.List();
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Get agent");
            string login = "k.gorski+2014102701@livechatinc.com";
            result = await Api.Agents.Get(login);
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
            login = "k.gorski+2015103102@livechatinc.com";
            props.Clear();
            props.Add("login_status", "not accepting chats");
            props.Add("max_chats_count", "2");
            result = await Api.Agents.Update(login, props);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Reset Api key");
            result = await Api.Agents.ResetApiKey(login);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Delete agent");
            result = await Api.Agents.Remove(login);
            Console.WriteLine(result);

            Console.WriteLine("");
        }

        public async Task ArchivesTest()
        {
            Console.WriteLine("Get chats");
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("date_from", "2015-10-01");
            parameters.Add("query", "test");
            string result = await Api.Archives.Get(parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Get chat");
            string chatID = "NXBE94NZ10";
            result = await Api.Archives.Get(chatID);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Send chat transcript");
            string email = "k.gorski@livechatinc.com";
            result = await Api.Archives.SendTranscript(chatID, email);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Update chat tags");
            string[] tags = { "sales", "complaint" };
            result = await Api.Archives.Tags(chatID, tags);
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
            string responseID = "18051";
            result = await Api.CannedResponses.Get(responseID);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Add canned response");
            string text = "text";
            string[] tags = {"tag1", "tag2"};
            result = await Api.CannedResponses.Add(text, tags);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Update canned response");
            responseID = "30131"; 
            string[] tags2 = { "tag3", "tag4" };
            result = await Api.CannedResponses.Update(responseID, tags2);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Delete canned response");
            result = await Api.CannedResponses.Remove(responseID);
            Console.WriteLine(result);
            
            Console.WriteLine("");
        }

        public async Task ChatTest()
        {
            Console.WriteLine("Start chat");
            string visitorID = "visitor123";
            string licenseID = "5164681";
            string welcomeMessage = "Hello";
            string result = await Api.Chat.StartChat(visitorID, licenseID, welcomeMessage);
            Console.WriteLine(result);
            
            Console.ReadLine();

            Console.WriteLine("Get pending messages");
            string sessionID = "CS1449238356.e911a7da96";
            result = await Api.Chat.GetPendingMessages(visitorID, licenseID, sessionID);
            Console.WriteLine(result);
            
            Console.ReadLine();

            Console.WriteLine("Send message");
            string message = "new message";
            result = await Api.Chat.SendMessage(visitorID, licenseID, sessionID, message);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Close chat");
            result = await Api.Chat.CloseChat(visitorID, licenseID, sessionID);
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
            string goalID = "7601";
            result = await Api.Goals.Get(goalID);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Mark goal as successful");
            string visitorID = "visitor1";
            result = await Api.Goals.MarkAsSuccessful(goalID, visitorID);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Add goal");
            string name = "new_goal";
            string type = "api";
            result = await Api.Goals.Add(name, type);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Update goal"); 
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("name", "purchase_paused");
            parameters.Add("active", "0");
            result = await Api.Goals.Update(goalID, parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Remove goal");
            result = await Api.Goals.Remove(goalID);
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
            string greetingID = "7661";
            result = await Api.Greetings.Get(greetingID);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Add greeting");
            string name = "my_invitation";
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
            result = await Api.Greetings.Add(name, rules, funnelRules);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Update greeting");
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("active","1");
            result = await Api.Greetings.Update(greetingID, parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Remove greeting");
            result = await Api.Greetings.Remove(greetingID);
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
            string groupID = "0";
            result = await Api.Groups.Get(groupID);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Add group");
            string name = "new_group";
            string[] agents = { "k.gorski+2014102701@livechatinc.com" };
            result = await Api.Groups.Add(name, agents);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Update group");
            groupID = "1";
            string[] agents2 = { "k.gorski+2014102701@livechatinc.com" };
            result = await Api.Groups.Update(groupID, agents2);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Remove group");
            result = await Api.Groups.Remove(groupID);
            Console.WriteLine(result);

            Console.WriteLine("");
        }

        public async Task ReportsTest()
        {
            Console.WriteLine("Total chats"); 
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("date_from", "2015-10-01");
            parameters.Add("date_to", "2015-10-31");
            string result = await Api.Reports.TotalChats(parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Chat sources");
            result = await Api.Reports.ChatSources(parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Chat ratings");
            result = await Api.Reports.ChatRatings(parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Chat ranking");
            result = await Api.Reports.ChatRanking(parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Queued visitors");
            result = await Api.Reports.QueuedVisitors(parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Queue waiting times");
            result = await Api.Reports.QueueWaitingTimes(parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Availability");
            result = await Api.Reports.Availability(parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Chatting time");
            result = await Api.Reports.ChattingTime(parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Chats first response time");
            result = await Api.Reports.ChatsFirstResponseTime(parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Chats response time");
            result = await Api.Reports.ChatsResponseTime(parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Goals");
            result = await Api.Reports.Goals(parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("New tickets");
            result = await Api.Reports.NewTickets(parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Tickets first response time");
            result = await Api.Reports.TicketsFirstResponseTime(parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Solved tickets");
            result = await Api.Reports.SolvedTickets(parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Tickets resolution time");
            result = await Api.Reports.TicketsResolutionTime(parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Ticket sources");
            result = await Api.Reports.TicketSources(parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Ticket ratings");
            result = await Api.Reports.TicketRatings(parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Ticket Ranking");
            result = await Api.Reports.TicketRanking(parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Greetings conversions");
            result = await Api.Reports.GreetingsConversions(parameters);
            Console.WriteLine(result);
            
            Console.ReadLine();

            Console.WriteLine("Number of simultaneous chats");
            string weekday = "mon";
            result = await Api.Reports.SimultaneousChats(weekday);
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

            Console.ReadLine();

            Console.WriteLine("Add tag");
            string author = "k.gorski+2014102701@livechatinc.com";
            string tag = "support";
            string groupID = "1";
            result = await Api.Tags.Add(author, tag, groupID);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Remove tag");
            result = await Api.Tags.Remove(tag, groupID);
            Console.WriteLine(result);

            Console.WriteLine("");
        }

        public async Task TicketsTest()
        {
            Console.WriteLine("Get tickets");
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("date_from", "2015-10-01");
            parameters.Add("date_to", "2015-12-31");
            string result = await Api.Tickets.List(parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Get ticket");
            string ticketID = "ZR8U4";
            result = await Api.Tickets.Get(ticketID);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Add ticket");
            string message = "ticket message";
            string requester = "requester@othercompany.com";
            parameters.Clear();
            parameters.Add("requester[name]", "Bill");
            result = await Api.Tickets.Add(message, requester, parameters);
            Console.WriteLine(result);

            Console.ReadLine();

            Console.WriteLine("Update tags");
            string[] tags = { "sales", "complaint" };
            result = await Api.Tickets.UpdateTags(ticketID, tags);
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
