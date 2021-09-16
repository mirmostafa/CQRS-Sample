﻿using System.Threading.Tasks;

namespace CqrsSample.Infra
{
    public class ValidationCommandHandlerDecorator<TCommand, TResult> : ICommandHandler<TCommand, TResult>
        where TCommand : ICommand
        where TResult : ICommandResult
    {
        private readonly ICommandHandler<TCommand, TResult> _DecoratedHandler;
        private readonly ICommandValidator<TCommand> _Validator;

        public ValidationCommandHandlerDecorator(ICommandHandler<TCommand, TResult> decoratedHandler, ICommandValidator<TCommand> validator)
        {
            this._DecoratedHandler = decoratedHandler;
            this._Validator = validator;
        }

        public async Task<CommandResult<TResult>> HandleAsync(TCommand command)
        {
            await this._Validator.ValidateAsync(command);
            return await this._DecoratedHandler.HandleAsync(command);
        }
    }
}