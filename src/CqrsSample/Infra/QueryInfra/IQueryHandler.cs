using System.Threading.Tasks;

namespace CqrsSample.Infra
{
    public interface IQueryHandler<in TQuery, TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}