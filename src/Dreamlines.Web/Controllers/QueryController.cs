using System.Threading.Tasks;
using Dreamlines.Data;
using Dreamlines.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Dreamlines.Web.Controllers {
    
    public abstract class QueryController<TQuery, TResult> : Controller
        where TQuery: IQuery<TResult> {
        
        public QueryController(IQueryProcessor queryProcessor) {
            QueryProcessor = queryProcessor;
        }
        
        protected IQueryProcessor QueryProcessor { get; }

        [HttpPost("search")]
        public async Task<IActionResult> Post([FromBody]TQuery query) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }

            return Json(await QueryProcessor.ProcessAsync(query));
        }
        
    }
    
}