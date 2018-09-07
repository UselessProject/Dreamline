using System;

namespace Dreamlines.Web.Models {

    public class Booking : IModel {
        public int Id { get; set; }
        public int ShipId { get; set; }
        public DateTime BookingDate { get; set; }
        public int Price { get; set; }
        public DateTime CreatedOn { get; set; }
        public Ship Ship { get; set; }
    }

}