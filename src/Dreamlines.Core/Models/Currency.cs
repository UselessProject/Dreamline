﻿using System;
using System.Collections.Generic;

namespace Dreamlines.Web.Models {

    public class Currency : IModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public IEnumerable<Country> Countries { get; set; }
        public DateTime CreatedOn { get; set; }
    }

}