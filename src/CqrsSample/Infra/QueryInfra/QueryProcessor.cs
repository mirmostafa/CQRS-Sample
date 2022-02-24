using Autofac;
using System.Threading.Tasks;

namespace CqrsSample.Infra
{
    public sealed class QueryProcessor : IQueryProcessor
    {
        private readonly ILifetimeScope _Container;

        public QueryProcessor(ILifetimeScope container) => this._Container = container;

        public Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query)
        {
            if (query is null)
            {
                throw new System.ArgumentNullException(nameof(query));
            }

            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            dynamic handler = this._Container.ResolveKeyed("1", handlerType);
            return handler.HandleAsync((dynamic)query);
        }
    }
}