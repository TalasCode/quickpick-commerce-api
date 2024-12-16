using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Core.DTO
{
    public class OfferDTO
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
    }
}
