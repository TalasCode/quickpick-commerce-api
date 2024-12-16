using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Core.Repositories.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserPermissionRepos UserPermissions { get; }
        public IUserRepos Users { get; }
        public IRoleRepos Roles { get; }
        public ICartRepos Carts { get; }
        public IOrderRepos Orders { get; }
        public IOfferRepos Offers { get; }

        public IOrderItemRepos OrderItems { get; }
        public ICouponRepos Coupons { get; }
        public ICategoryRepos Category { get; }

        public IBrandRepos Brands { get; }
        public IItemRepos Items { get; }

        public IReviewRepos Reviews { get; }
        public IWishListItemRepos WishListItems { get; }
       public IAuthRepos Auths { get; }
        Task<int> CommitAsync();
    }
}
