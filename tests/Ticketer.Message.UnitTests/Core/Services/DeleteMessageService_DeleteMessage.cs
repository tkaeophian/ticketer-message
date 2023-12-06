using Ardalis.Result;
using Ardalis.SharedKernel;
using Ticketer.Message.Core.MessageAggregate;
using Ticketer.Message.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Ticketer.Message.UnitTests.Core.Services;

public class DeleteMessageService_DeleteMessage
{
    private readonly ILogger<DeleteMessageService> _logger = Substitute.For<ILogger<DeleteMessageService>>();
    private readonly IMediator _mediator = Substitute.For<IMediator>();
    private readonly IRepository<Message.Core.MessageAggregate.Message> _repository = Substitute.For<IRepository<Message.Core.MessageAggregate.Message>>();

    private readonly DeleteMessageService _service;

    public DeleteMessageService_DeleteMessage()
    {
        _service = new DeleteMessageService(_repository, _mediator, _logger);
    }

    [Fact]
    public async Task ReturnsNotFoundGivenCantFindMessage()
    {
        var result = await _service.DeleteMessage(0);

        Assert.Equal(ResultStatus.NotFound, result.Status);
    }
}
