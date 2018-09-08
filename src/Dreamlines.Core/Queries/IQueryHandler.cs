using System.Threading.Tasks;

namespace Dreamlines.Data {

    public interface IQueryHandler<TResult> {
        Task<TResult> ExecuteAsync(IQuery<TResult> query);
    }
    
    public interface IQueryHandler<in TQuery, TResult> : IQueryHandler<TResult>
        where TQuery : IQuery<TResult> {

        Task<TResult> ExecuteAsync(TQuery query);
    }
    
}