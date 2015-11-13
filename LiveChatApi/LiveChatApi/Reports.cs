using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LiveChatApi
{
    public class Reports
    {
        private IApiHandler Api;

        public Reports(IApiHandler api)
        {
            Api = api;
        }

        public async Task<string> Get(string uri, Dictionary<string,string>parameters)
        {
            string paramString = "";
            if (parameters != null && parameters.Count > 0)
            {
                foreach (var keyValuePair in parameters)
                {
                    if (paramString.Length == 0)
                    {
                        paramString += "?";
                    }
                    else
                    {
                        paramString += "&";
                    }
                    
                    paramString += string.Format("{0}={1}", keyValuePair.Key, HttpUtility.UrlEncode(keyValuePair.Value));
                }
            }
            if (paramString.Length > 0)
            {
                uri += paramString;
            }

            return await Api.Get(uri);
        }

        public async Task<string> TotalChats(Dictionary<string, string> parameters)
        {
            string uri = "reports/chats/total_chats";
            return await Get(uri, parameters);
        }

        public async Task<string> ChatSources(Dictionary<string, string> parameters)
        {
            string uri = "reports/chats/source";
            return await Get(uri, parameters);
        }

        public async Task<string> ChatRatings(Dictionary<string, string> parameters)
        {
            string uri = "reports/chats/ratings";
            return await Get(uri, parameters);
        }

        public async Task<string> ChatRanking(Dictionary<string, string> parameters)
        {
            string uri = "chats/ratings/ranking";
            return await Get(uri, parameters);
        }

        public async Task<string> QueuedVisitors(Dictionary<string, string> parameters)
        {
            string uri = "reports/chats/queued_visitors";
            return await Get(uri, parameters);
        }

        public async Task<string> QueueWaitingTimes(Dictionary<string, string> parameters)
        {
            string uri = "reports/chats/queued_visitors/waiting_times";
            return await Get(uri, parameters);
        }

        public async Task<string> Availability(Dictionary<string, string> parameters)
        {
            string uri = "reports/availability";
            return await Get(uri, parameters);
        }

        public async Task<string> ChattingTime(Dictionary<string, string> parameters)
        {
            string uri = "reports/chats/chatting_time";
            return await Get(uri, parameters);
        }

        public async Task<string> ChatsFirstResponseTime(Dictionary<string, string> parameters)
        {
            string uri = "reports/chats/first_response_time";
            return await Get(uri, parameters);
        }

        public async Task<string> ChatsResponseTime(Dictionary<string, string> parameters)
        {
            string uri = "reports/chats/response_time";
            return await Get(uri, parameters);
        }

        public async Task<string> Goals(Dictionary<string, string> parameters)
        {
            string uri = "reports/chats/goals";
            return await Get(uri, parameters);
        }

        public async Task<string> NewTickets(Dictionary<string, string> parameters)
        {
            string uri = "reports/tickets/new_tickets";
            return await Get(uri, parameters);
        }

        public async Task<string> TicketsFirstResponseTIme(Dictionary<string, string> parameters)
        {
            string uri = "reports/tickets/first_response_time";
            return await Get(uri, parameters);
        }

        public async Task<string> SolvedTickets(Dictionary<string, string> parameters)
        {
            string uri = "reports/tickets/solved_tickets";
            return await Get(uri, parameters);
        }

        public async Task<string> TicketsResolutionTime(Dictionary<string, string> parameters)
        {
            string uri = "reports/tickets/resolution_time";
            return await Get(uri, parameters);
        }

        public async Task<string> TicketSources(Dictionary<string, string> parameters)
        {
            string uri = "reports/tickets/ticket_sources";
            return await Get(uri, parameters);
        }

        public async Task<string> TicketRatings(Dictionary<string, string> parameters)
        {
            string uri = "reports/tickets/ratings";
            return await Get(uri, parameters);
        }

        public async Task<string> TicketRanking(Dictionary<string, string> parameters)
        {
            string uri = "reports/tickets/ratings/ranking";
            return await Get(uri, parameters);
        }

        public async Task<string> GreetingsConversions(Dictionary<string, string> parameters)
        {
            string uri = "reports/greetings";
            return await Get(uri, parameters);
        }

        public async Task<string> SimultaneousChats(Dictionary<string, string> parameters)
        {
            string uri = "reports/chats/agents_occupancy";
            return await Get(uri, parameters);
        }
    }
}
