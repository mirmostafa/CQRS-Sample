using System;
using System.Threading.Tasks;
using CqrsSample.Infra;

namespace CqrsSample.Sample.UserEntity.Command
{
    public class CreateUserCommandValidator : ICommandValidator<CreateUserCommand>
    {
        public ValueTask ValidateAsync(CreateUserCommand command)
        {
            Console.WriteLine("ValidateAsync...");

            return new ValueTask();
        }
    }
}