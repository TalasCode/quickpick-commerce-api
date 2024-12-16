using System;
using System.Collections.Generic;

namespace eCommerceAPI.Core.Models;

public partial class WishlistItem
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ItemId { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
