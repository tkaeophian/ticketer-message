using Ardalis.SharedKernel;
using Ticketer.Message.UseCases.Messages.Create;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ticketer.Message.UnitTests.UseCases.Messages;

public class CreateMessageHandlerHandle
{
    private readonly IRepository<Message.Core.MessageAggregate.Message> _repository = Substitute.For<IRepository<Message.Core.MessageAggregate.Message>>();
    private readonly string _testName = "test message";
    private readonly CreateMessageHandler _handler;

    public CreateMessageHandlerHandle()
    {
        _handler = new CreateMessageHandler(_repository);
    }

    private Message.Core.MessageAggregate.Message CreateMessage()
    {
        return new Message.Core.MessageAggregate.Message(_testName);
    }

    [Fact]
    public async Task ReturnsSuccessGivenValidName()
    {
        _repository.AddAsync(Arg.Any<Message.Core.MessageAggregate.Message>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(CreateMessage()));
        var result = await _handler.Handle(new CreateMessageCommand(_testName), CancellationToken.None);

        result.IsSuccess.Should().BeTrue();
    }
}
