using Ardalis.HttpClientTestExtensions;
using Ticketer.Message.Infrastructure.Data;
using Ticketer.Message.Web.Messages;
using Xunit;

namespace Ticketer.Message.FunctionalTests.ApiEndpoints;


[Collection("Sequential")]
public class MessageList
    (CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task ReturnsTwoContributors()
    {
        var result = await _client.GetAndDeserializeAsync<MessageListResponse>("/messages");

        Assert.Equal(2, result.Messages.Count);
        Assert.Contains(result.Messages, i => i.Content == SeedData.Message1.Content);
        Assert.Contains(result.Messages, i => i.Content == SeedData.Message2.Content);
    }
}
