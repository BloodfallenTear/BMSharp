using System;
using System.Net.Http;

namespace BMSharp
{
    public class BattleMetrics
    {
        internal static HttpClient HttpClient { get; private set; }

        private String BearerToken { get; set; }

        public BattleMetrics() 
        {
            BattleMetrics.HttpClient = new HttpClient();
            BattleMetrics.HttpClient.DefaultRequestHeaders.ConnectionClose = true;
        }

        public BattleMetrics(String BearerToken) : this()
        {
            this.BearerToken = BearerToken;
        }
    }
}
