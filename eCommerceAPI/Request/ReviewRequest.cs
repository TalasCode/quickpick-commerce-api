namespace eCommerceAPI.Request
{
    public class ReviewRequest
    {
        public int ItemId { get; set; }

        public int UserId { get; set; }

        public int Rating { get; set; }

        public string? Comment { get; set; }
    }
}
