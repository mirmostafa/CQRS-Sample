using CqrsSample.Infra;

namespace CqrsSample.Sample.UserEntity.Command
{
    public class CreateUserCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}