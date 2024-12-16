using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Core.DTO
{
    public class CouponDTO
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public decimal DiscountAmount { get; set; }

        public decimal DiscountPercentage { get; set; }

        public DateTime ExpiryDate { get; set; }

        public bool IsActive { get; set; }

    }
}
