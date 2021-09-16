using System.Threading.Tasks;

namespace CqrsSample.Infra
{
    public interface ICommandValidator<in TCommand> where TCommand : ICommand
    {
        ValueTask ValidateAsync(TCommand command);
    }
}