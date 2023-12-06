using Ticketer.Message.UseCases.Messages.List;
using FastEndpoints;
using MediatR;

namespace Ticketer.Message.Web.Messages;

public class List(IMediator _mediator) : EndpointWithoutRequest<MessageListResponse>
{
    public override void Configure()
    {
        Get("/messages");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new ListMessagesQuery(null, null));

        if (result.IsSuccess)
        {
            Response = new MessageListResponse
            {
                Messages = result.Value.Select(c => new MessageRecord(c.Id, c.Content)).ToList()
            };
        }
    }
}
