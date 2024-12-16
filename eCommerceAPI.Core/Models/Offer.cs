using System;
using System.Collections.Generic;

namespace eCommerceAPI.Core.Models;

public partial class Offer
{
    public int Id { get; set; }

    public int? ItemId { get; set; }

    public string? Description { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal DiscountPercentage { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int? CategoryId { get; set; }

    public int? BrandId { get; set; }

    public string? Picture { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Item? Item { get; set; }
}
