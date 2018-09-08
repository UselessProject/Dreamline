using System.Collections.Generic;

namespace Dreamlines.Data {

    public interface IPaginatedQuery<TResult> : IQuery<IEnumerable<TResult>> {
        int Skip { get; set; }
        int Limit { get; set; }
    }

}