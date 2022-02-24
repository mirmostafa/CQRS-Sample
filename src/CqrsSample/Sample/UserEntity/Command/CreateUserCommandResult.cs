using CqrsSample.Infra;
using System;

namespace CqrsSample.Sample.UserEntity.Command
{
    public class CreateUserCommandResult : ICommandResult
    {
        public Guid Id { get; set; }
    }
}