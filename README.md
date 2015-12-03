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
string result = await Api.Chats.Get(parameters);
~~~

**Get single chat**
~~~
string chatID = "NXBE94NZ10";
string result = await Api.Chats.Get(chatID);
~~~

**Send chat transcript to e-mail**
~~~
string chatID = "NXBE94NZ10";
string email = "username@mycompany.com";
string result = await Api.Chats.SendTranscript(chatID, email);
~~~

**Update chat tags**
~~~
string chatID = "NXBE94NZ10";
string[] tags = { "sales", "complaint" };
string result = await Api.Chats.Tags(chatID, tags);
~~~

### Canned responses

[Canned responses REST API documentation](http://developers.livechatinc.com/rest-api/#!canned-responses).

**List all canned responses**
~~~
string result = await Api.CannedResponses.List();
~~~
~~~
string group = "0";
string result = await Api.CannedResponses.List(group);
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
string group = "0";
string result = await Api.CannedResponses.Add(text, tags, group);
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

### Groups

[Groups REST API documentation](http://developers.livechatinc.com/rest-api/#!groups).


### Reports

[Reports REST API documentation](http://developers.livechatinc.com/rest-api/#!reports).


### Status

[Status REST API documentation](http://developers.livechatinc.com/rest-api/#!status).

### Tags

[Tags REST API documentation](https://developers.livechatinc.com/rest-api/#!tags).

### Tickets

[Tickets REST API documentation](http://developers.livechatinc.com/rest-api/#!tickets).


### Visitors

[Visitors REST API documentation](http://developers.livechatinc.com/rest-api/#!visitors).

### Webhooks

[Webhooks REST API documentation](https://developers.livechatinc.com/rest-api/#!webhooks).

