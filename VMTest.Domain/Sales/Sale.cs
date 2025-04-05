namespace VMTest.Domain.Sales
{
    public sealed class Sale
    {
        public required string Segment { get; set; }
        public required string Country { get; set; }
        public required string Product { get; set; }
        public required string DiscountBand { get; set; }
        public decimal UnitsSold { get; set; }
        public decimal ManufacturingPrice { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime Date { get; set; }
    }
}
