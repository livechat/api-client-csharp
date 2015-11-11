using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveChatApi
{
    public interface IApiHandler
    {
        Task<string> Get(string uri);
        Task<string> Post(string uri, string content);
        Task<string> Put(string uri, string content);
        Task<string> Delete(string uri);
    }
}
