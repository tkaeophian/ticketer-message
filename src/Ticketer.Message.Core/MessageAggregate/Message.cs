using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace Ticketer.Message.Core.MessageAggregate;

public class Message(string content) : EntityBase, IAggregateRoot
{
    public string Content { get; private set; } = content;
    public DateTime CreatedAt { get; set; }
    
}
