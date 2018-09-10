namespace Dreamlines.Dtos {
    
    public class SalesUnitSummary {
        public int SalesUnitId { get; set; }
        public string CountryName { get; set; }
        public string SalesUnitName { get; set; }
        public int TotalBooking { get; set; }
        public double TotalPrice { get; set; }
        public string CurrencySymbol { get; set; }
    }
    
}