using System.Linq;
using Dreamlines.Dtos;
using Dreamlines.Models;

namespace Dreamlines.Data {
    
    public class BookingQueryHandler
        : PaginatedQueryHandler<BookingQuery, BookingSummary> {

        public BookingQueryHandler(DreamlinesContext dbContext) {
            Context = dbContext;
        }
        
        protected DreamlinesContext Context { get; }
        
        protected override IQueryable<BookingSummary> ExecuteCore(BookingQuery query) {
            return 
                from ship in Context.Ships
                join booking in Context.Bookings on ship.Id equals booking.ShipId
                where ship.SalesUnitId == query.SalesUnitId &&
                      booking.BookingDate >= query.FromDate &&
                      booking.BookingDate <= query.ToDate
                select new BookingSummary {
                    BookingId = booking.Id,
                    ShipId = booking.ShipId,
                    ShipName = ship.Name,
                    Price = booking.Price,
                    BookingDate = booking.BookingDate
                };
        }
        
    }
    
}