namespace Ticketer.Message.Web.Messages;

public class MessageListResponse
{
    public List<MessageRecord> Messages { get; set; } = new();
}
