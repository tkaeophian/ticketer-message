using Ardalis.Result;
using Ardalis.SharedKernel;
using Ticketer.Message.Core.MessageAggregate;

namespace Ticketer.Message.UseCases.Messages.Create;

public class CreateMessageHandler(IRepository<Core.MessageAggregate.Message> _repository)
    : ICommandHandler<CreateMessageCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateMessageCommand request,
        CancellationToken cancellationToken)
    {
        var newContributor = new Core.MessageAggregate.Message(request.Content);
        var createdItem = await _repository.AddAsync(newContributor, cancellationToken);

        return createdItem.Id;
    }
}
