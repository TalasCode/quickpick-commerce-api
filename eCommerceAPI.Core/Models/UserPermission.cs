using System;
using System.Collections.Generic;

namespace eCommerceAPI.Core.Models;
public partial class UserPermission
{
    public int Id { get; set; }

    public int? RoleId { get; set; }

    public string Permission { get; set; } = null!;

    public virtual Role? Role { get; set; }
}
