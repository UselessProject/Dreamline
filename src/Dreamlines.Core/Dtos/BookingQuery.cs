using System;
using System.ComponentModel.DataAnnotations;
using Dreamlines.Dtos;

namespace Dreamlines.Dtos {
    
    public class BookingQuery: IPaginatedQuery<BookingSummary> {
        public int Skip { get; set; } = 0;
        [Range(1, 100)]
        public int Limit { get; set; } = 100;
        [Required]
        public int? SalesUnitId { get; set; }
        [Required]
        public DateTime? FromDate { get; set; }
        [Required]
        public DateTime? ToDate { get; set; }
    }
    
}