using Ticketer.Message.Core.MessageAggregate;
using Xunit;

namespace Ticketer.Message.UnitTests.Core.MessageAggregate;

public class MessageConstructor
{
    private readonly string _testName = "test message";
    private Message.Core.MessageAggregate.Message? _testMessage;

    private Message.Core.MessageAggregate.Message CreateMessage()
    {
        return new Message.Core.MessageAggregate.Message(_testName);
    }

    [Fact]
    public void InitializesName()
    {
        _testMessage = CreateMessage();

        Assert.Equal(_testName, _testMessage.Content);
    }
}
