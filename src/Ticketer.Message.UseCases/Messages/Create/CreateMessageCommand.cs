using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Ticketer.Message.UseCases.Messages.Create;

public record CreateMessageCommand(string Content) : ICommand<Result<int>>;
