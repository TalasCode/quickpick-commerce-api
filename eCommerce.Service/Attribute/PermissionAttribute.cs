using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Service.Attribute
{
    public class PermissionAttribute 
    {
        public string RequiredPermission { get; set; }

        public PermissionAttribute(string requiredPermission)
        {
            RequiredPermission = requiredPermission;
        }
    }
}
