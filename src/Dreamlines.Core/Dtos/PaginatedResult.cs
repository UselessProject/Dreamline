using System.Collections.Generic;

namespace Dreamlines.Dtos {
    
    public class PaginatedResult<TResult> {

        public PaginatedResult(int skip, int limit, int total, IEnumerable<TResult> result) {
            Skip = skip;
            Limit = limit;
            Total = total;
            Result = result;
        }
        
        public int Skip { get; }
        public int Limit { get; }
        public int Total { get; }
        public IEnumerable<TResult> Result { get; }
        
    }
    
}