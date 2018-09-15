using System;

namespace Dreamlines.Dtos {
    
    public class BookingSummary {
        public int BookingId { get; set; }
        public int ShipId { get; set; }
        public string ShipName { get; set; }
        public double Price { get; set; }
        public string CurrencySymbol { get; set; }
        public DateTime BookingDate { get; set; }
    }
    
}