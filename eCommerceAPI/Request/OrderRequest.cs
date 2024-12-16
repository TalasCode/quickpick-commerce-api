namespace eCommerceAPI.Request
{
    public class OrderRequest
    {
        public int UserId { get; set; }

        public string OrderStatus { get; set; } = null!;

        public DateTime OrderDate { get; set; }

        public int? CouponId { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Street { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Zipcode { get; set; }

        public string? Country { get; set; }

        public string? Phone { get; set; }
        public decimal? Amount { get; set; }

    }
}
