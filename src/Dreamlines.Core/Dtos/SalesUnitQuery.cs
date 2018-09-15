using System;
using System.ComponentModel.DataAnnotations;
using Dreamlines.Dtos;

namespace Dreamlines.Dtos {
    
    public class SalesUnitQuery: IPaginatedQuery<SalesUnitSummary> {
        public int Skip { get; set; } = 0;
        [Range(1, 100)]
        public int Limit { get; set; } = 100;
        [Required]
        public DateTime? FromDate { get; set; }
        [Required]
        public DateTime? ToDate { get; set; }
        public int? SalesUnitId { get; set; }
    }
    
}