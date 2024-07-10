namespace CurrencyConverter.Services.DTOs
{
    public class HistoricalRatesResponseDTO
    {
        public decimal Amount { get; set; }
        public string Base { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PagedRatesResponseDTO Rates { get; set; }
        public HistoricalRatesResponseDTO() { Rates = new PagedRatesResponseDTO(); }
    }

    public class PagedRatesResponseDTO
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public Dictionary<DateTime, Dictionary<string, decimal>> Rates { get; set; }
    }
}
