namespace Ticketer.Message.UseCases.Messages.List;

public interface IListMessagesQueryService
{
    Task<IEnumerable<MessageDTO>> ListAsync();
}
