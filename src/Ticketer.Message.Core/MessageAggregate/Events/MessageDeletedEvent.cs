using Ardalis.SharedKernel;

namespace Ticketer.Message.Core.MessageAggregate.Events;

internal sealed class MessageDeletedEvent(int id) : DomainEventBase
{
    public int Id { get; init; } = id;
}
