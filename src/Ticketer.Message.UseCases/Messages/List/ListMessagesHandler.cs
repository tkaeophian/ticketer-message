using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Ticketer.Message.UseCases.Messages.List;

public class ListMessagesHandler(IListMessagesQueryService _query)
    : IQueryHandler<ListMessagesQuery, Result<IEnumerable<MessageDTO>>>
{
    public async Task<Result<IEnumerable<MessageDTO>>> Handle(ListMessagesQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _query.ListAsync();

        return Result.Success(result);
    }
}
