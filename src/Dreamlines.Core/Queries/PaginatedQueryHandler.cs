using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dreamlines.Data {

    public abstract class PaginatedQueryHandler<TQuery, TResult>
        : IQueryHandler<TQuery, IEnumerable<TResult>>
        where TQuery : IPaginatedQuery<TResult> {

        protected abstract IQueryable<TResult> ExecuteCore(TQuery query);

        public virtual async Task<IEnumerable<TResult>> ExecuteAsync(TQuery query) {
            var result = ExecuteCore(query);
            return await result
                .Skip(query.Skip)
                .Take(query.Limit)
                .ToArrayAsync();
        }

        #region [IQueryHandler members]
        
        Task<IEnumerable<TResult>> IQueryHandler<IEnumerable<TResult>>.ExecuteAsync(
            IQuery<IEnumerable<TResult>> query
        ) {
            return ExecuteAsync((TQuery) query);
        }
        
        #endregion

    }

}