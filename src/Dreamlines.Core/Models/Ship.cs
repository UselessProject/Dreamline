using System;
using System.Collections.Generic;

namespace Dreamlines.Web.Models {

    public class Ship : IModel {
        public int Id { get; set; }
        public int SalesUnitId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public SalesUnit SalesUnit { get; set; }
        public IEnumerable<Booking> Booking { get; set; }
    }

}