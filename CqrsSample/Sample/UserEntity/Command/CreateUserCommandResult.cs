using System;
using CqrsSample.Infra;

namespace CqrsSample.Sample.UserEntity.Command
{
    public class CreateUserCommandResult : ICommandResult
    {
        public Guid Id { get; set; }
    }
}