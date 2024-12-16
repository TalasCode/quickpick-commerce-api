namespace eCommerceAPI.Request
{
    public class CouponRequest
    {
        public string Code { get; set; } = null!;

        public decimal DiscountAmount { get; set; }

        public decimal DiscountPercentage { get; set; }

        public DateTime ExpiryDate { get; set; }

        public bool IsActive { get; set; }

    }
}
