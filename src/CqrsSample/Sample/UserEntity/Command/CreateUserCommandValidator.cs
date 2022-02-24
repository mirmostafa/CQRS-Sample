using CqrsSample.Infra;
using System;
using System.Threading.Tasks;

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