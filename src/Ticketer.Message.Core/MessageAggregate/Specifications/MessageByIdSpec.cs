using Ardalis.Specification;

namespace Ticketer.Message.Core.MessageAggregate.Specifications;

public sealed class MessageByIdSpec : Specification<Message>
{
    public MessageByIdSpec(int id)
    {
        Query.Where(message => message.Id == id);
    }
}
