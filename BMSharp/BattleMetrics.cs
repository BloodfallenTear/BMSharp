using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Threading;

namespace BMSharp
{
    internal sealed class RequiresTokenAttribute : Attribute
    {

    }

    /// <summary> The BattleMetrics API wrapper. </summary>
    public sealed class BattleMetrics : IDisposable
    {
        internal const String BASE_URL = "https://api.battlemetrics.com";

        internal String Token { get; }

        internal HttpClient HttpClient { get; }
        internal CancellationTokenSource CancellationTokenSource { get; }
        internal CancellationToken CancellationToken => this.CancellationTokenSource.Token;

        public Server Server { get; }

        private Boolean disposed = false;

        /// <summary> The BattleMetrics API wrapper. </summary>
        public BattleMetrics() 
        {
            var httpHandler = new HttpClientHandler
            {
                UseCookies = false,
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
            };

            this.HttpClient = new HttpClient(httpHandler) { Timeout = TimeSpan.FromSeconds(5.0d) };
            this.HttpClient.DefaultRequestHeaders.ConnectionClose = true;

            this.CancellationTokenSource = new CancellationTokenSource();

            this.Server = new Server(this);
        }

        /// <summary> The BattleMetrics API wrapper. By adding a Bearer Token, new features may become available and the ratelimits may be higher. </summary>
        /// <param name="token">Your Bearer Token. You may create a Bearer Token from the <see href="https://www.battlemetrics.com/developers">BattleMetrics Developers Area</see>.</param>
        public BattleMetrics(String token) : this()
        {
            this.Token = token;
            this.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.Token);
        }

        ~BattleMetrics() => this.Dispose();

        public void Dispose()
        {
            if (this.disposed)
                return;

            this.disposed = true;

            this.HttpClient.Dispose();
        }
    }

    /// <summary> Servers. </summary>
    public sealed class Server
    {
        private BattleMetrics BattleMetrics { get; }

        /// <summary> Servers. </summary>
        internal Server(BattleMetrics battleMetrics) => this.BattleMetrics = battleMetrics;

        public void GetInfo(String serverId)
        {

        }
    }
}
