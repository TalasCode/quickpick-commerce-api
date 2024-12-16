namespace eCommerceAPI.Request
{
    public class ItemRequest
    {
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public int? BrandId { get; set; }

        public int? CategoryId { get; set; }

        public int? Stock { get; set; }

        public string? Picture { get; set; }
    }
}
