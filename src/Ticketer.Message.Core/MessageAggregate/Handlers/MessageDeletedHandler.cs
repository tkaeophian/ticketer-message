using MediatR;
using Microsoft.Extensions.Logging;
using Ticketer.Message.Core.MessageAggregate.Events;

namespace Ticketer.Message.Core.MessageAggregate.Handlers;

internal class MessageDeletedHandler(ILogger<MessageDeletedHandler> _logger) : INotificationHandler<MessageDeletedEvent>
{
    public async Task Handle(MessageDeletedEvent domainEvent, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling Contributed Deleted event for {contributorId}", domainEvent.Id);

        // TODO: do meaningful work here
        await Task.Delay(1);
    }
}
