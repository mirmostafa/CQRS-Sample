using System;
using CqrsSample.Infra;

namespace CqrsSample.Sample.UserEntity.Query
{
    public class GetUserByIdQuery : IQuery<GetUserByIdQueryResult>
    {
        public Guid Id { get; set; }
    }
}