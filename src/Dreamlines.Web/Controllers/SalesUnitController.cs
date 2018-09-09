using System.Collections.Generic;
using Dreamlines.Data;
using Dreamlines.Dtos;
using Dreamlines.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Dreamlines.Controllers {

    [Route("/api/[controller]")]
    public class SalesUnitController : QueryController<SalesUnitQuery, PaginatedResult<SalesUnitSummary>> {

        public SalesUnitController(IQueryProcessor queryProcessor)
            : base(queryProcessor) {
        }

    }

}