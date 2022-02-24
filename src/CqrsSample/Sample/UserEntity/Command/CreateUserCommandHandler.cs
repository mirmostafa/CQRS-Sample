using System;
using System.Threading.Tasks;
using CqrsSample.Infra;

namespace CqrsSample.Sample.UserEntity.Command
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, CreateUserCommandResult>
    {
        private readonly DbContext dbContext;

        public CreateUserCommandHandler(DbContext dbContext) => this.dbContext = dbContext;
        public Task<CommandResult<CreateUserCommandResult>> HandleAsync(CreateUserCommand command)
        {
            var entity = new User
            {
                Id = Guid.NewGuid(),
                FirstName = command.FirstName,
                LastName = command.LastName
            };
            this.dbContext.Users.Add(entity);

            var result = new CreateUserCommandResult { Id = entity.Id };
            return Task.FromResult(CommandResult<CreateUserCommandResult>.Success(result));
        }
    }
}