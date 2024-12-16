namespace eCommerceAPI.Request
{
    public class CartRequest
    {
        public int UserId { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }
    }
}
