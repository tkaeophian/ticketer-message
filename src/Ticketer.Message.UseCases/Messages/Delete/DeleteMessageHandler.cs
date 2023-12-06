using Ardalis.Result;
using Ardalis.SharedKernel;
using Ticketer.Message.Core.Interfaces;

namespace Ticketer.Message.UseCases.Messages.Delete;

public class DeleteMessageHandler(IDeleteMessageService _deleteMessageService)
    : ICommandHandler<DeleteMessageCommand, Result>
{
    public async Task<Result> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
    {
        // This Approach: Keep Domain Events in the Domain Model / Core project; this becomes a pass-through
        return await _deleteMessageService.DeleteMessage(request.MessageId);

        // Another Approach: Do the real work here including dispatching domain events - change the event from internal to public
        // @ardalis prefers using the service above so that **domain** event behavior remains in the **domain model** (core project)
        // var aggregateToDelete = await _repository.GetByIdAsync(request.ContributorId);
        // if (aggregateToDelete == null) return Result.NotFound();

        // await _repository.DeleteAsync(aggregateToDelete);
        // var domainEvent = new ContributorDeletedEvent(request.ContributorId);
        // await _mediator.Publish(domainEvent);
        // return Result.Success();
    }
}
