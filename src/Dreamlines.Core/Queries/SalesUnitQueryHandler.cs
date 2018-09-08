using System.Linq;
using Dreamlines.Dtos;
using Dreamlines.Models;

namespace Dreamlines.Data {

    public class SalesUnitQueryHandler : PaginatedQueryHandler<SalesUnitQuery, SalesUnitSummary> {

        public SalesUnitQueryHandler(DreamlinesContext context) {
            Context = context;
        }

        protected DreamlinesContext Context { get; }

        protected override IQueryable<SalesUnitSummary> ExecuteCore(SalesUnitQuery query) {
            return
                from unit in Context.SalesUnits
                join ship in Context.Ships on unit.Id equals ship.SalesUnitId
                join booking in Context.Bookings on ship.Id equals booking.ShipId
                where booking.BookingDate >= query.FromDate && booking.BookingDate <= query.ToDate
                group booking by new {unit.Id, unit.Name}
                into g
                select new SalesUnitSummary {
                    Id = g.Key.Id,
                    Name = g.Key.Name,
                    TotalPrice = g.Sum(e => e.Price)
                };
        }

    }

}