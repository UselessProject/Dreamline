using System;
using System.Threading.Tasks;

namespace Dreamlines.Data {
    
    public interface IQueryProcessor {
        IQueryProcessor AddHandler<TQuery, THandler>();
        Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query);
    }
    
}