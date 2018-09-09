using System;
using System.Collections.Generic;

namespace Dreamlines.Models {

    public class Country : IModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public IEnumerable<SalesUnit> SalesUnits { get; set; }
    }

}
