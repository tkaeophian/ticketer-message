using Ardalis.Result;

namespace Ticketer.Message.Core.Interfaces;

public interface IDeleteMessageService
{
    public Task<Result> DeleteMessage(int id);
}
