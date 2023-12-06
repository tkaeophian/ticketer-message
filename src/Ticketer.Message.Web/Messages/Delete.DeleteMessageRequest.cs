namespace Ticketer.Message.Web.Messages;

public class DeleteMessageRequest
{
    public const string Route = "/messages/{messageId:int}";

    public int MessageId { get; set; }

    public static string BuildRoute(int messageId)
    {
        return Route.Replace("{messageId:int}", messageId.ToString());
    }
}
