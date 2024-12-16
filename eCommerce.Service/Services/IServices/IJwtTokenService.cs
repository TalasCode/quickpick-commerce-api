using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Service.Services.IServices
{
   public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}
