using eCommerceAPI.Core.Models;
using eCommerceAPI.Core.Repositories.IRepositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace eCommerceAPI.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DatabaseServerContext _context;
        private readonly IConfiguration _configuration;

        private IUserRepos? _userRepository;
        private IRoleRepos? _roleRepository;
        private ICartRepos? _cartRepository;
        private ICategoryRepos? _categoryRepository;
        private IBrandRepos? _brandRepository;
        private IOfferRepos? _offerRepository;
        private IOrderRepos? _orderRepository;
        private IOrderItemRepos? _orderItemRepository;
        private IWishListItemRepos? _wishListItemRepository;
        private ICouponRepos? _couponRepository;
        private IReviewRepos? _reviewRepository;
        private IItemRepos? _itemRepository;
        private IUserPermissionRepos? _userPermissionRepository;
        private IAuthRepos? _authRepository;

        public UnitOfWork(DatabaseServerContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IUserRepos Users =>
            _userRepository ??= new UserRepos(_context);
        public IRoleRepos Roles => 
            _roleRepository ??= new RoleRepos(_context);
        public IOfferRepos Offers => 
            _offerRepository ??= new OfferRepos(_context);
        public IOrderItemRepos OrderItems => 
            _orderItemRepository ??= new OrderItemRepos(_context);
        public IOrderRepos Orders => 
            _orderRepository ??= new OrderRepos(_context);
        public IItemRepos Items => 
            _itemRepository ??= new ItemRepos(_context);
        public IWishListItemRepos WishListItems => 
            _wishListItemRepository ??= new WishListItemRepos(_context);
        public ICartRepos Carts => 
            _cartRepository ??= new CartRepos(_context);
        public ICategoryRepos Category => 
            _categoryRepository ??= new CategoryRepos(_context);
        public IBrandRepos Brands => 
            _brandRepository ??= new BrandRepos(_context);
        public ICouponRepos Coupons => 
            _couponRepository ??= new CouponRepos(_context);
        public IReviewRepos Reviews => 
            _reviewRepository ??= new ReviewRepos(_context);
        public IUserPermissionRepos UserPermissions =>
            _userPermissionRepository ??= new UserPermissionRepos(_context);

        public IAuthRepos Auths =>
            _authRepository ??= new AuthRepos(_context);
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}