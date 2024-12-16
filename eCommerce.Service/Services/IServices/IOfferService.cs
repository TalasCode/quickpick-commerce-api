using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Services.IServices
{
    public interface IOfferService
    {
        Task<List<OfferDTO>?> GetAllOffers();
        Task<Offer?> GetOfferById(int id);
        Task<List<OfferDTO>?> GetOfferByCategory(int categoryId);
        Task<List<OfferDTO>?> GetOfferByBrand(int brandId);
        Task<Offer> AddOffer(Offer offer);
        Task<Offer> UpdateOffer(Offer offer);
        Task<bool> DeleteOffer(int id);
    }
}
