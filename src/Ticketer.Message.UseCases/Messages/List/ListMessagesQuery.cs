using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Ticketer.Message.UseCases.Messages.List;

public record ListMessagesQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<MessageDTO>>>;
