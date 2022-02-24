using System.Threading.Tasks;

namespace CqrsSample.Infra
{
    public interface ICommandProcessor
    {
        Task<CommandResult<TResult>> ExecuteAsync<TCommand, TResult>(TCommand command);
    }
}