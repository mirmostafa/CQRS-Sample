using CqrsSample.Infra;
using CqrsSample.Sample.UserEntity.Command;
using CqrsSample.Sample.UserEntity.Query;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CqrsSample.Sample
{
    public abstract class ApiControllerBase
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly ICommandProcessor _commandProcessor;

        protected ApiControllerBase(IQueryProcessor queryProcessor, ICommandProcessor commandProcessor)
        {
            this._queryProcessor = queryProcessor;
            this._commandProcessor = commandProcessor;
        }

        public async Task<CommandResult<IEnumerable<GetUserByIdQueryResult>>> GetAll() => throw new NotImplementedException();

        public async Task<GetUserByIdQueryResult> GetById(Guid id) => await this._queryProcessor.ExecuteAsync(new GetUserByIdQuery { Id = id });

        public async Task<CommandResult<Guid>> Post(CreateUserCommand command) => await this._commandProcessor.ExecuteAsync<CreateUserCommand, Guid>(command);

        public async Task<CommandResult> Put(Guid id, CreateUserCommand command) => throw new NotImplementedException();

        public async Task<CommandResult> Delete(Guid id) => throw new NotImplementedException();
    }
}