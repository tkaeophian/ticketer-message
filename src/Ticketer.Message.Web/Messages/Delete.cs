using Ardalis.Result;
using FastEndpoints;
using MediatR;
using Ticketer.Message.UseCases.Messages.Delete;

namespace Ticketer.Message.Web.Messages;

public class Delete(IMediator _mediator) : Endpoint<DeleteMessageRequest>
{
    public override void Configure()
    {
        Delete(DeleteMessageRequest.Route);
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        DeleteMessageRequest request,
        CancellationToken cancellationToken)
    {
        var command = new DeleteMessageCommand(request.MessageId);

        var result = await _mediator.Send(command);

        if (result.Status == ResultStatus.NotFound)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        if (result.IsSuccess)
        {
            await SendNoContentAsync(cancellationToken);
        }
    }
}
