using System.Collections.Generic;
using Dreamlines.Data;
using Dreamlines.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Dreamlines.Web.Controllers {

    [Route("/api/[controller]")]
    public class BookingController : QueryController<BookingQuery, PaginatedResult<BookingSummary>> {

        public BookingController(IQueryProcessor queryProcessor)
            : base(queryProcessor) {
        }

    }

}