using System.Threading.Tasks;

namespace CqrsSample.Infra
{
    public interface ICommandHandler<in TCommand, TResult>
        where TCommand : ICommand
        where TResult : ICommandResult
    {
        Task<CommandResult<TResult>> HandleAsync(TCommand command);
    }
}