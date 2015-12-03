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

**Get a single agent details**
~~~
string result = await Api.Agents.Get("robert@mycompany.com");
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
Dictionary<string, string> props = new Dictionary<string, string>();
props.Add("login_status", "not accepting chats");
props.Add("max_chats_count", "2");
string result = await Api.Agents.Update("john@mycompany.com", props);
~~~

**Reset an API key**
~~~
string result = await Api.Agents.ResetApiKey("username@mycompany.com");
~~~
*The agent can only change his own api key.*

**Remove an agent**
~~~
result = await Api.Agents.Remove("john@mycompany.com");
~~~

### Archives

[Archives REST API documentation](https://developers.livechatinc.com/rest-api/#!archives).


### Canned responses

[Canned responses REST API documentation](http://developers.livechatinc.com/rest-api/#!canned-responses).


### Chat

[Chat REST API documentation](http://developers.livechatinc.com/rest-api/#!chats).


### Goals

[Goals REST API documentation](http://developers.livechatinc.com/rest-api/#!goals).

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

