namespace eCommerceAPI.Request
{
    public class OfferRequest
    {
        public int? ItemId { get; set; }

        public string? Description { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal DiscountPercentage { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int? CategoryId { get; set; }

        public int? BrandId { get; set; }
        public string? Picture { get; set; }

    }
}
