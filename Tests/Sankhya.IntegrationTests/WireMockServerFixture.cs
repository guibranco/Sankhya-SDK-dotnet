using System;
using WireMock.Server;
using WireMock.Settings;

namespace Sankhya.IntegrationTests
{
    public class WireMockServerFixture : IDisposable
    {
        public WireMockServer Server { get; }

        public WireMockServerFixture()
        {
            Server = WireMockServer.Start(new WireMockServerSettings
            {
                Urls = new[] { "http://localhost:9091" }
            });
        }

        public void Dispose()
        {
            Server.Stop();
        }
    }
}
