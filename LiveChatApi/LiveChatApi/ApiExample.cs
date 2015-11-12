using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveChatApi
{
    class ApiExample
    {
        public async Task Start()
        {
            Api api = new Api("k.gorski+2014102701@livechatinc.com", "bf34a8c7cb49d63eea03ddb6b964319e");

            try
            {
                string agents = await api.Agents.List();
                Console.WriteLine("Agents: {0}", agents);

                Console.ReadLine();

                string agent = await api.Agents.Get("k.gorski+2014102701@livechatinc.com");
                Console.WriteLine("Agent: {0}", agent);

                Console.ReadLine();

                Dictionary<string, string> props = new Dictionary<string, string>();
                props.Add("login", "k.gorski+2015103102@livechatinc.com");
                props.Add("name", "John");

                string newAgent = await api.Agents.Add(props);
                Console.WriteLine("New agent: {0}", newAgent);

                Console.ReadLine();

                props.Clear();
                props.Add("login_status", "not accepting chats");
                props.Add("max_chats_count", "2");

                string updatedAgent = await api.Agents.Update("k.gorski+2015103102@livechatinc.com", props);
                Console.WriteLine("Updated agent: {0}", updatedAgent);

                Console.ReadLine();

                string resetApiKeyResult = await api.Agents.ResetApiKey("k.gorski+2015103102@livechatinc.com");
                Console.WriteLine("Reset Api key: {0}", resetApiKeyResult);

                Console.ReadLine();

                string deletedAgent = await api.Agents.Remove("k.gorski+2015103102@livechatinc.com");
                Console.WriteLine("Deleted agent: {0}", deletedAgent);

                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception {0}", ex.ToString());
            }
        }
    }
}
