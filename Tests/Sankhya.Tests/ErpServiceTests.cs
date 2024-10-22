using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;
using Snapshooter.Xunit;

namespace Sankhya.Tests
{
    public class ErpServiceTests : IClassFixture<WireMockServerFixture>
    {
        private readonly WireMockServerFixture _fixture;

        public ErpServiceTests(WireMockServerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Should_Handle_Successful_Response()
        {
            // Arrange
            _fixture.Server
                .Given(Request.Create().WithPath("/api/orders").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBody("{ \"orderId\": \"12345\" }"));

            // Act
            var result = await _service.GetOrderAsync("12345");

            // Assert
            Assert.Equal("12345", result.OrderId);
        }

        [Fact]
        public async Task Should_Match_Expected_Response()
        {
            // Act
            var actualResponse = await _service.GetOrderAsync("12345");

            // Assert
            Snapshot.Match(actualResponse);
        }
    }
}
