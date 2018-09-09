using System;
using System.Collections.Generic;

namespace Dreamlines.Models {

    public class SalesUnit : IModel {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public IEnumerable<Ship> Ships { get; set; }
    }

}
