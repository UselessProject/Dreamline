namespace Dreamlines.Dtos {

    public interface IPaginatedQuery<TResult> : IQuery<PaginatedResult<TResult>> {
        int Skip { get; set; }
        int Limit { get; set; }
    }

}