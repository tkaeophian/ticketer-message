using Ticketer.Message.UseCases.Messages;
using Ticketer.Message.UseCases.Messages.List;
using Microsoft.EntityFrameworkCore;

namespace Ticketer.Message.Infrastructure.Data.Queries;


public class ListMessagesQueryService(AppDbContext _db) : IListMessagesQueryService
{
    public async Task<IEnumerable<MessageDTO>> ListAsync()
    {
        var result = await _db.Messages
            .Select(c => new MessageDTO(c.Id, c.Content, c.CreatedAt))
            .ToListAsync();

        return result;
    }
}
