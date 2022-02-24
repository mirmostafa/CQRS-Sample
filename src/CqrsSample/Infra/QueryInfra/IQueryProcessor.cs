using System.Threading.Tasks;

namespace CqrsSample.Infra
{
    public interface IQueryProcessor
    {
        Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query);
    }
}