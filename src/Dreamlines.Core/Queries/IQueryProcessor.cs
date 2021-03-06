using System.Threading.Tasks;
using Dreamlines.Dtos;

namespace Dreamlines.Data {
    
    public interface IQueryProcessor {
//        IQueryProcessor MapHandler<TQuery, THandler>();
        Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query);
    }
    
}