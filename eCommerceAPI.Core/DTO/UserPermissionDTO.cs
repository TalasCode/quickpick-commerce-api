using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Core.DTO
{
    public class UserPermissionDTO
    {
        public int Id { get; set; }

        public int? RoleId { get; set; }

        public string Permission { get; set; } = null!;
    }
}
