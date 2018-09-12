using System.Threading.Tasks;
using Dreamlines.Dtos;

namespace Dreamlines.Data {
    
    public class SalesUnitByIdQueryHandler : IQueryHandler<SalesUnitByIdQuery, SalesUnitSummary> {

        public Task<SalesUnitSummary> ExecuteAsync(SalesUnitByIdQuery query) {
            throw new System.NotImplementedException();
        }
        
        Task<SalesUnitSummary> IQueryHandler<SalesUnitSummary>.ExecuteAsync(IQuery<SalesUnitSummary> query) {
            return ExecuteAsync((SalesUnitByIdQuery)query);
        }
        
    }
    
}