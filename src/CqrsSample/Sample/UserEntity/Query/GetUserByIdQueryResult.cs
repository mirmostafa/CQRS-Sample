using System.Diagnostics;

namespace CqrsSample.Sample.UserEntity.Query
{
    [DebuggerDisplay("Query result: FirstName={FirstName}, LastName={LastName}")]
    public class GetUserByIdQueryResult
    {
        public GetUserByIdQueryResult()
        {
        }

        public GetUserByIdQueryResult(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}