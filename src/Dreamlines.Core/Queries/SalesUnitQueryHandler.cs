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
                join country in Context.Countries on unit.CountryId equals country.Id
                join currency in Context.Currencies on country.CurrencyId equals currency.Id
                join ship in Context.Ships on unit.Id equals ship.SalesUnitId
                join booking in Context.Bookings on ship.Id equals booking.ShipId
                where booking.BookingDate >= query.FromDate && 
                      booking.BookingDate <= query.ToDate
                group booking by new {
                    unit.Id, 
                    SalesUnitName = unit.Name, 
                    CountryName = country.Name, 
                    CurrencySymbol = currency.Symbol
                } into g
                orderby g.Key.Id
                select new SalesUnitSummary {
                    SalesUnitId = g.Key.Id,
                    CountryName = g.Key.CountryName,
                    SalesUnitName = g.Key.SalesUnitName,
                    TotalBooking = g.Count(),
                    TotalPrice = g.Sum(e => e.Price),
                    CurrencySymbol = g.Key.CurrencySymbol
                };
        }

    }

}