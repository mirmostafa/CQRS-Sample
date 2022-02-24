using CqrsSample.Infra;
using System.Linq;
using System.Threading.Tasks;

namespace CqrsSample.Sample.UserEntity.Query
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, GetUserByIdQueryResult>
    {
        public GetUserByIdQueryHandler(DbContext dbContext) => this.DbContext = dbContext;

        public DbContext DbContext { get; }

        public Task<GetUserByIdQueryResult> HandleAsync(GetUserByIdQuery query)
        {
            var dbResult = this.DbContext.Users.FirstOrDefault(u => u.Id == query.Id);
            return Task.FromResult(new GetUserByIdQueryResult(dbResult.FirstName, dbResult.LastName));
        }
    }
}