using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Ticketer.Message.UseCases.Messages.Delete;

public record DeleteMessageCommand(int MessageId) : ICommand<Result>;
