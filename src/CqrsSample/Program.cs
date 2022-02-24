using CqrsSample.Infra;
using CqrsSample.Sample.UserEntity.Command;
using CqrsSample.Sample.UserEntity.Query;
using System;
using System.Threading.Tasks;

namespace CqrsSample
{
    internal class Program
    {
        private static void Main()
        {
            Application.Init();
            (var queryProcessor, var commandProcessor) = Application.GetProcessors(); // 🤔 It is initializing processors. What about the next time usage? Initializing every single time?

            var resultCommand = SampleCommand(commandProcessor);

            Console.WriteLine($"Id: {resultCommand.Result.Id}");

            Console.WriteLine("...................");

            var resultQuery = SampleQuery(queryProcessor, resultCommand.Result.Id);

            Console.WriteLine($"{resultQuery.Result.FirstName} {resultQuery.Result.LastName}");
        }

        private static CommandResult<CreateUserCommandResult> SampleCommand(ICommandProcessor commandProcessor)
        {
            var command = new CreateUserCommand { FirstName = "Alex", LastName = "Christopher" }; // Comes from API
            var resultCommand = commandProcessor.ExecuteAsync<CreateUserCommand, CreateUserCommandResult>(command);
            return resultCommand.Result;
        }

        private static Task<GetUserByIdQueryResult> SampleQuery(IQueryProcessor queryProcessor, Guid id)
        {
            var resultQuery = queryProcessor.ExecuteAsync(new GetUserByIdQuery { Id = id });
            return resultQuery;
        }
    }
}