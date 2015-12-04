LiveChat API C# Client
==============

C# library with ready-to-use LiveChat API implementation.

Documentation
-------------

To find out more, visit the official [LiveChat REST API documentation](http://developers.livechatinc.com/rest-api/#!introduction).

Requirements
------------

- .Net Framework 4.5 or greater

Authentication to the API occurs via HTTP Basic Auth. Provide your:

- login
- API key

More information: http://developers.livechatinc.com/rest-api/#authentication

Installation
------------

1. Clone the repository
2. Copy LiveChatApi project into your Solution folder
3. Right-click on your Solution in Solution Explorer and add existing project
4. Add a reference to LiveChatApi in your project's References

Usage
------------

~~~
public class ApiExample
{
    LiveChatApi.Api Api;

    public ApiExample()
    {
        Api = new LiveChatApi.Api("username@mycompany.com", "API_KEY");
        GetAgents().Wait()
    }
    
    public async void GetAgents()
    {
        string result = await Api.Agents.List();
        Console.WriteLine(result);
    }
}
~~~

Available methods
------------

### Agents

[Agents REST API documentation](http://developers.livechatinc.com/rest-api/#!agents).

**List all agents**
~~~
string result = await Api.Agents.List();
~~~
~~~
string status = "accepting chats";
string result = await Api.Agents.List(status);
~~~

**Get a single agent details**
~~~
string login = "robert@mycompany.com";
string result = await Api.Agents.Get(login);
~~~

**Create an agent**
~~~
Dictionary<string, string> props = new Dictionary<string, string>();
props.Add("login", "john@mycompany.com");
props.Add("name", "John");
string result = await Api.Agents.Add(props);
~~~

**Update an agent**
~~~
string login = "john@mycompany.com";
Dictionary<string, string> props = new Dictionary<string, string>();
props.Add("login_status", "not accepting chats");
props.Add("max_chats_count", "2");
string result = await Api.Agents.Update(login, props);
~~~

**Reset an API key**
~~~
string login = "username@mycompany.com";
string result = await Api.Agents.ResetApiKey(login);
~~~
*The agent can only change his own api key.*

**Remove an agent**
~~~
string login = "john@mycompany.com";
string result = await Api.Agents.Remove(login);
~~~

### Archives

[Archives REST API documentation](https://developers.livechatinc.com/rest-api/#!archives).

**Get list of chats**
~~~
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("date_from", "2015-10-01");
parameters.Add("query", "test");
string result = await Api.Archives.Get(parameters);
~~~

**Get single chat**
~~~
string chatID = "NXBE94NZ10";
string result = await Api.Archives.Get(chatID);
~~~

**Send chat transcript to e-mail**
~~~
string chatID = "NXBE94NZ10";
string email = "username@mycompany.com";
string result = await Api.Archives.SendTranscript(chatID, email);
~~~

**Update chat tags**
~~~
string chatID = "NXBE94NZ10";
string[] tags = { "sales", "complaint" };
string result = await Api.Archives.Tags(chatID, tags);
~~~

### Canned responses

[Canned responses REST API documentation](http://developers.livechatinc.com/rest-api/#!canned-responses).

**List all canned responses**
~~~
string result = await Api.CannedResponses.List();
~~~
~~~
string groupID = "0";
string result = await Api.CannedResponses.List(groupID);
~~~

**Get single canned response**
~~~
string responseID = "3151";
string result = await Api.CannedResponses.Get(responseID);
~~~

**Create a new canned response**
~~~
string text = "text";
string[] tags = {"tag1", "tag2"};
string result = await Api.CannedResponses.Add(text, tags);
~~~
~~~
string text = "text";
string[] tags = {"tag1", "tag2"};
string groupID = "0";
string result = await Api.CannedResponses.Add(text, tags, groupID);
~~~

**Update a canned response**
~~~
string responseID = "3151";
string[] tags = { "tag3", "tag4" };
string result = await Api.CannedResponses.Update(responseID, tags);
~~~
~~~
string responseID = "3151";
string[] tags = { "tag3", "tag4" };
string text = "text";
string result = await Api.CannedResponses.Update(responseID, tags, text);
~~~

**Remove a canned response**
~~~
string responseID = "3151";
string result = await Api.CannedResponses.Remove(responseID);
~~~

### Chat

[Chat REST API documentation](http://developers.livechatinc.com/rest-api/#!chats).

**Start chat**
~~~
string visitorID = "visitor123";
string licenseID = "123456";
string welcomeMessage = "Hello";
string result = await Api.Chat.StartChat(visitorID, licenseID, welcomeMessage);
~~~
~~~
string visitorID = "visitor123";
string licenseID = "123456";
string welcomeMessage = "Hello";
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("name", "Barbara");
parameters.Add("email", "barbara@othercompany.com");
string result = await Api.Chat.StartChat(visitorID, licenseID, welcomeMessage, parameters);
~~~

**Get pending messages**
~~~
string visitorID = "visitor123";
string licenseID = "123456";
string sessionID = "CS1449238356.e911a7da96";
string result = await Api.Chat.GetPendingMessages(visitorID, licenseID, sessionID);
~~~

**Send message**
~~~
string visitorID = "visitor123";
string licenseID = "123456";
string sessionID = "CS1449238356.e911a7da96";
string message = "new message";
string result = await Api.Chat.SendMessage(visitorID, licenseID, sessionID, message);
~~~

**Close chat**
~~~
string visitorID = "visitor123";
string licenseID = "123456";
string sessionID = "CS1449238356.e911a7da96";
string result = await Api.Chat.CloseChat(visitorID, licenseID, sessionID);
~~~


### Goals

[Goals REST API documentation](http://developers.livechatinc.com/rest-api/#!goals).

**List all goals**
~~~
string result = await Api.Goals.List();
~~~

**Get a single goal details**
~~~
string goalID = "7601";
string result = await Api.Goals.Get(goalID);
~~~

**Mark goal as successful**
~~~
string goalID = "7601";
string visitorID = "visitor1";
string result = await Api.Goals.MarkAsSuccessful(goalID, visitorID);
~~~

**Add a new goal**
~~~
string name = "new_goal";
string type = "api";
string result = await Api.Goals.Add(name, type);
~~~
~~~
string name = "new_goal";
string type = "url";
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("url", "http://www.mystore.com/checkout/thank_you");
parameters.Add("match_type","exact");
string result = await Api.Goals.Add(name, type, parameters);
~~~

**Update a goal**
~~~
string goalID = "7601";
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("name", "new_goal_paused");
parameters.Add("active", "0");
string result = await Api.Goals.Update(goalID, parameters);
~~~

**Remove a goal**
~~~
string goalID = "7601";
string result = await Api.Goals.Remove(goalID);
~~~

### Greetings

[Greetings REST API documentation](https://developers.livechatinc.com/rest-api/#!greetings).

**List all greetings**
~~~
string result = await Api.Greetings.List();
~~~
~~~
string groupID = "0";
string result = await Api.Greetings.List(groupID);
~~~

**Get a single greeting**
~~~
string greetingID = "7661";
string result = await Api.Greetings.Get(greetingID);
~~~

**Create a new greeting**
~~~
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
string result = await Api.Greetings.Add(name, rules, funnelRules);
~~~
~~~
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
string groupID = "0";
string result = await Api.Greetings.Add(name, rules, funnelRules, groupID);
~~~

**Update a greeting**
~~~
string greetingID = "7661";
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("active","1");
string result = await Api.Greetings.Update(greetingID, parameters);
~~~

**Remove a greeting**
~~~
string greetingID = "7661";
string result = await Api.Greetings.Remove(greetingID);
~~~

### Groups

[Groups REST API documentation](http://developers.livechatinc.com/rest-api/#!groups).

**List all groups**
~~~
string result = await Api.Groups.List();
~~~

**Get a single group details**
~~~
string groupID = "0";
string result = await Api.Groups.Get(groupID);
~~~

**Create a new group**
~~~
string name = "new_group";
string[] agents = { "robert@mycompany.com", "john@mycompany.com" };
string result = await Api.Groups.Add(name, agents);
~~~
~~~
string name = "new_group";
string[] agents = { "robert@mycompany.com", "john@mycompany.com" };
string language = "es";
string result = await Api.Groups.Add(name, agents, language);
~~~

**Update a group**
~~~
string groupID = "1";
string[] agents = { "robert@mycompany.com" };
result = await Api.Groups.Update(groupID, agents);
~~~
~~~
string groupID = "1";
string[] agents = { "robert@mycompany.com" };
string name = "other_name";
result = await Api.Groups.Update(groupID, agents, name);
~~~
~~~
string groupID = "1";
string[] agents = { "robert@mycompany.com" };
string name = "other_name";
string language = "de"
result = await Api.Groups.Update(groupID, agents, name, language);
~~~

**Remove a group**
~~~
string groupID = "1";
string result = await Api.Groups.Remove(groupID);
~~~


### Reports

[Reports REST API documentation](http://developers.livechatinc.com/rest-api/#!reports).

**Total chats**
~~~
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("date_from", "2015-10-01");
parameters.Add("date_to", "2015-10-31");
parameters.Add("agent", "john@mycompany.com");
parameters.Add("group_by", "hour");
string result = await Api.Reports.TotalChats(parameters);
~~~

**Chat sources**
~~~
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("date_from", "2015-10-01");
parameters.Add("date_to", "2015-10-31");
parameters.Add("agent", "john@mycompany.com");
parameters.Add("group_by", "hour");
parameters.Add("tag[]", "sales");
string result = await Api.Reports.ChatSources(parameters);
~~~

**Chat ratings**
~~~
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("group", "2");
parameters.Add("date_from", "2015-01-01");
parameters.Add("date_to", "2015-10-31");
parameters.Add("group_by", "month");
string result = await Api.Reports.ChatRatings(parameters);
~~~

**Chat ranking**
~~~
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("date_from", "2015-10-01");
parameters.Add("date_to", "2015-10-31");
string result = await Api.Reports.ChatRanking(parameters);
~~~

**Queued visitors**
~~~
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("date_from", "2015-10-01");
parameters.Add("date_to", "2015-10-31");
parameters.Add("group", "2");
string result = await Api.Reports.QueuedVisitors(parameters);
~~~

**Queue waiting times**
~~~
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("date_from", "2015-10-01");
parameters.Add("date_to", "2015-10-31");
parameters.Add("group", "2");
string result = await Api.Reports.QueueWaitingTimes(parameters);
~~~

**Availability**
~~~
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("date_from", "2015-10-01");
parameters.Add("date_to", "2015-10-31");
parameters.Add("agent", "john@mycompany.com");
string result = await Api.Reports.Availability(parameters);
~~~

**Chatting time**
~~~
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("date_from", "2015-10-01");
parameters.Add("date_to", "2015-10-31");
parameters.Add("group", "2");
string result = await Api.Reports.ChattingTime(parameters);
~~~

**Chats first response time**
~~~
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("date_from", "2015-10-01");
parameters.Add("date_to", "2015-10-31");
parameters.Add("agent", "john@mycompany.com");
string result = await Api.Reports.ChatsFirstResponseTime(parameters);
~~~

**Chats response time**
~~~
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("date_from", "2015-10-01");
parameters.Add("date_to", "2015-10-31");
parameters.Add("agent", "john@mycompany.com");
string result = await Api.Reports.ChatsResponseTime(parameters);
~~~

**Goals**
~~~
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("date_from", "2015-01-01");
parameters.Add("date_to", "2015-10-31");
parameters.Add("goal", "71");
parameters.Add("group_by", "month");
string result = await Api.Reports.Goals(parameters);
~~~

**New tickets**
~~~
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("date_from", "2015-10-01");
parameters.Add("date_to", "2015-10-01");
parameters.Add("group_by", "hour");
string result = await Api.Reports.NewTickets(parameters);
~~~

**Tickets first response time**
~~~
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("date_from", "2015-10-01");
parameters.Add("date_to", "2015-10-31");
parameters.Add("agent", "john@mycompany.com");
string result = await Api.Reports.TicketsFirstResponseTime(parameters);
~~~

**Solved tickets**
~~~
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("date_from", "2015-10-01");
parameters.Add("date_to", "2015-10-31");
string result = await Api.Reports.SolvedTickets(parameters);
~~~

**Tickets resolution time**
~~~
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("date_from", "2015-10-01");
parameters.Add("date_to", "2015-10-31");
string result = await Api.Reports.TicketsResolutionTime(parameters);
~~~

**Ticket sources**
~~~
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("date_from", "2015-10-01");
parameters.Add("date_to", "2015-10-31");
string result = await Api.Reports.TicketSources(parameters);
~~~

**Ticket ratings report**
~~~
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("date_from", "2015-01-01");
parameters.Add("date_to", "2015-10-31");
parameters.Add("group_by", "month");
string result = await Api.Reports.TicketRatings(parameters);
~~~

**Ticket Ranking**
~~~
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("date_from", "2015-10-01");
parameters.Add("date_to", "2015-10-31");
string result = await Api.Reports.TicketRanking(parameters);
~~~

**Greetings conversions**
~~~
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("date_from", "2015-01-01");
parameters.Add("date_to", "2015-10-31");
parameters.Add("group_by", "month");
string result = await Api.Reports.GreetingsConversions(parameters);
~~~

**Number of simultaneous chats**
~~~
string weekday = "mon";
string result = await Api.Reports.SimultaneousChats(weekday);
~~~

### Status

[Status REST API documentation](http://developers.livechatinc.com/rest-api/#!status).

**Get status**
~~~
string result = await Api.Status.Get();
~~~
~~~
string groupID = "1";
string result = await Api.Status.Get(groupID);
~~~

### Tags

[Tags REST API documentation](https://developers.livechatinc.com/rest-api/#!tags).

**List all tags**
~~~
string result = await Api.Tags.List();
~~~
~~~
string groupID = "1";
string result = await Api.Tags.Get(groupID);
~~~

**Add a tag**
~~~
string author = "john@mycompany.com";
string tag = "support";
string groupID = "1";
string result = await Api.Tags.Add(author, tag, groupID);
~~~

**Delete a tag**
~~~
string tag = "support";
string groupID = "1";
string result = await Api.Tags.Remove(tag, groupID);
~~~

### Tickets

[Tickets REST API documentation](http://developers.livechatinc.com/rest-api/#!tickets).

**Get list of tickets**
~~~
string result = await Api.Tickets.List();
~~~
~~~
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("date_from", "2015-10-01");
parameters.Add("date_to", "2015-12-31");
string result = await Api.Tickets.List(parameters);
~~~

**Get single ticket**
~~~
string ticketID = "ZR8U4";
string result = await Api.Tickets.Get(ticketID);
~~~

**Create a ticket**
~~~
string message = "ticket message";
string requester = "requester@othercompany.com";
string result = await Api.Tickets.Add(message, requester);
~~~
~~~
string message = "ticket message";
string requester = "requester@othercompany.com";
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("requester[name]", "Bill");
string result = await Api.Tickets.Add(message, requester, parameters);
~~~

**Update ticket tags**
~~~
string ticketID = "ZR8U4";
string[] tags = { "sales", "complaint" };
string result = await Api.Tickets.UpdateTags(ticketID, tags);
~~~

### Visitors

[Visitors REST API documentation](http://developers.livechatinc.com/rest-api/#!visitors).

**List all visitors**
~~~
string result = await Api.Visitors.List();
~~~
~~~
Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add("state", "chatting");
parameters.Add("group[]", "0");
string result = await Api.Visitors.List(parameters);
~~~

**Add custom visitor details**
~~~
string visitorID = "visitor123";
string licenseID = "5164681";
string token = "token";
string id = "my-app";
Dictionary<string, string> fields = new Dictionary<string, string>();
fields.Add("name1", "value1");
string result = await Api.Visitors.AddCustomDetails(visitorID, licenseID, token, id, fields);
~~~
~~~
string visitorID = "visitor123";
string licenseID = "5164681";
string token = "token";
string id = "my-app";
Dictionary<string, string> fields = new Dictionary<string, string>();
fields.Add("name1", "value1");
string icon = "http://www.mycompany.com/icon.png";
string result = await Api.Visitors.AddCustomDetails(visitorID, licenseID, token, id, fields, icon);
~~~

### Webhooks

[Webhooks REST API documentation](https://developers.livechatinc.com/rest-api/#!webhooks).

