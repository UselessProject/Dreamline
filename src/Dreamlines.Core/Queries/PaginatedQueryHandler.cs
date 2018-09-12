using System.Linq;
using System.Threading.Tasks;
using Dreamlines.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Dreamlines.Data {

    public abstract class PaginatedQueryHandler<TQuery, TResult>
        : IQueryHandler<TQuery, PaginatedResult<TResult>>
        where TQuery : IPaginatedQuery<TResult> {

        protected abstract IQueryable<TResult> ExecuteCore(TQuery query);

        public virtual async Task<PaginatedResult<TResult>> ExecuteAsync(TQuery query) {
            var unfilteredQuery = ExecuteCore(query);
            
            var filteredQuery = unfilteredQuery
                .Skip(query.Skip)
                .Take(query.Limit);

            return new PaginatedResult<TResult>(
                query.Skip,
                query.Limit,
                await unfilteredQuery.CountAsync(),
                await filteredQuery.ToArrayAsync()
            );
        }

        #region [IQueryHandler members]
        
        Task<PaginatedResult<TResult>> IQueryHandler<PaginatedResult<TResult>>.ExecuteAsync(
            IQuery<PaginatedResult<TResult>> query
        ) {
            return ExecuteAsync((TQuery) query);
        }
        
        #endregion

    }

}