using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CqrsSample.Infra;
using CqrsSample.Sample.UserEntity.Command;
using CqrsSample.Sample.UserEntity.Query;

namespace CqrsSample.Sample
{
    public abstract class ApiControllerBase
    {
        private readonly IQueryProcessor _QueryProcessor;
        private readonly ICommandProcessor _CommandProcessor;

        protected ApiControllerBase(IQueryProcessor queryProcessor, ICommandProcessor commandProcessor)
        {
            this._QueryProcessor = queryProcessor;
            this._CommandProcessor = commandProcessor;
        }

        public async Task<CommandResult<IEnumerable<GetUserByIdQueryResult>>> GetAll() => throw new NotImplementedException();
        public async Task<GetUserByIdQueryResult> GetById(Guid id) => await this._QueryProcessor.ExecuteAsync(new GetUserByIdQuery { Id = id });
        public async Task<CommandResult<Guid>> Post(CreateUserCommand command) => await this._CommandProcessor.ExecuteAsync<CreateUserCommand, Guid>(command);
        public async Task<CommandResult> Put(Guid id, CreateUserCommand command) => throw new NotImplementedException();
        public async Task<CommandResult> Delete(Guid id) => throw new NotImplementedException();
    }
}