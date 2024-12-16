using AutoMapper;
using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using eCommerceAPI.Request;

namespace eCommerceAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {

            
            CreateMap<UserRequest,User>();
            CreateMap<CartRequest,Cart>();
            CreateMap<OrderRequest, Order>();
            CreateMap<Offer, OfferRequest>();
            CreateMap<OfferRequest, Offer>();
            CreateMap<OrderItemRequest, OrderItem>();
            CreateMap<Review, ReviewRequest>();
            CreateMap<CategoryRequest, Category>();
            CreateMap<Category, CategoryRequest>();
            CreateMap<BrandRequest, Brand>();
            CreateMap<Brand,BrandRequest>();
            CreateMap<CouponRequest, Coupon>();
            CreateMap<ItemRequest, Item>();
            CreateMap<WishListItemRequest, WishlistItem>();
            CreateMap<CartRequest,CartDTO>();
            CreateMap<RoleRequest, Role>();
            CreateMap<UserPermissionRequest, UserPermission>();
        }
    }
}
