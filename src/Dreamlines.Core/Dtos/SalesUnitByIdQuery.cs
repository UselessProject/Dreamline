namespace Dreamlines.Dtos {

    public class SalesUnitByIdQuery : IQuery<SalesUnitSummary> {
        public int SalesUnitId { get; set; }
    }

}