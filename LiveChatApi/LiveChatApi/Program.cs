using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveChatApi
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiExample example = new ApiExample();
            example.Start().Wait();
        }
    }
}
