using System;
using System.Collections.Generic;
using Dreamlines.Models;

namespace Dreamlines.Tests.Integrations {

    public class DreamlinesTestDbInitializer : IDreamlinesDbInitializer {

        public void Initialize(DreamlinesContext db) {
            db.Ships.AddRange(GetShips());
            db.Bookings.AddRange(GetBookings());
            db.SaveChanges();
        }

        private IEnumerable<Ship> GetShips() {
            yield return new Ship {
                Id = 1,
                Name = "Ship 1",
                SalesUnitId = 1
            };
            
            yield return new Ship {
                Id = 2,
                Name = "Ship 2",
                SalesUnitId = 1
            };
            
            yield return new Ship {
                Id = 3,
                Name = "Ship 3",
                SalesUnitId = 4
            };
        }

        private IEnumerable<Booking> GetBookings() {
            yield return new Booking {
                Id = 1,
                BookingDate = DateTime.UtcNow.AddDays(-2),
                Price = 1000,
                ShipId = 1
            };
            
            yield return new Booking {
                Id = 2,
                BookingDate = DateTime.UtcNow.AddDays(-1),
                Price = 2000,
                ShipId = 2
            };

            yield return new Booking {
                Id = 3,
                BookingDate = DateTime.UtcNow.AddDays(-4),
                Price = 1500,
                ShipId = 3
            };
            
            yield return new Booking {
                Id = 4,
                BookingDate = DateTime.UtcNow.AddDays(-1),
                Price = 1500,
                ShipId = 3
            };
        } 
        
    }
    
}