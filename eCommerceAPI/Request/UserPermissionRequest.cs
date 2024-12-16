namespace eCommerceAPI.Request
{
    public class UserPermissionRequest
    {
        public int? RoleId { get; set; }

        public string Permission { get; set; } = null!;
    }
}
