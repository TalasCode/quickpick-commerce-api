using System;
using System.Collections.Generic;

namespace eCommerceAPI.Core.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
