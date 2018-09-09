using System;

namespace Dreamlines.Models {

    public class Booking : IModel {
        public int Id { get; set; }
        public int ShipId { get; set; }
        public DateTime BookingDate { get; set; }
        public double Price { get; set; }
        public Ship Ship { get; set; }
    }

}