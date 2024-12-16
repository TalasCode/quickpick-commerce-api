using System;
using System.Collections.Generic;

namespace eCommerceAPI.Core.Models;
public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Picture { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
}
