using Ardalis.Result;
using Ardalis.SharedKernel;
using Ticketer.Message.Core.MessageAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using Ticketer.Message.Core.Interfaces;
using Ticketer.Message.Core.MessageAggregate.Events;

namespace Ticketer.Message.Core.Services;

public class DeleteMessageService(
    IRepository<MessageAggregate.Message> _repository,
    IMediator _mediator,
    ILogger<DeleteMessageService> _logger) : IDeleteMessageService
{
    public async Task<Result> DeleteMessage(int id)
    {
        _logger.LogInformation("Deleting Message {id}", id);
        var aggregateToDelete = await _repository.GetByIdAsync(id);
        if (aggregateToDelete == null)
        {
            return Result.NotFound();
        }

        await _repository.DeleteAsync(aggregateToDelete);
        var domainEvent = new MessageDeletedEvent(id);
        await _mediator.Publish(domainEvent);
        return Result.Success();
    }
}
