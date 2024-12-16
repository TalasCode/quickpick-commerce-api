using eCommerce.Service.Services.IServices;
using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using eCommerceAPI.Core.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Service.Services
{
    public class OfferService(IUnitOfWork unitOfWork) : IOfferService
    {
        public async Task<List<OfferDTO>?> GetAllOffers()
        {
            try
            {
                var offers = await unitOfWork.Offers.GetAll();
                return offers;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<Offer?> GetOfferById(int id)
        {

            try
            {
                var offer = await unitOfWork.Offers.GetByIdAsync(id);
                return offer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<List<OfferDTO>?> GetOfferByCategory(int categoryId)
        {
            try
            {
                var offers = await unitOfWork.Offers.GetOfferByCategory(categoryId);
                return offers;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<List<OfferDTO>?> GetOfferByBrand(int brandId)
        {
            try
            {
                var offers = await unitOfWork.Offers.GetOfferByBrand(brandId);
                return offers;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
       public async Task<Offer> AddOffer(Offer offer)
        {
            try
            {
                await unitOfWork.Offers.AddAsync(offer);
                return offer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<Offer> UpdateOffer(Offer offer)
        {
            try
            {

                await unitOfWork.Offers.UpdateAsync(offer);
                await unitOfWork.CommitAsync();
                return offer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
       public async Task<bool> DeleteOffer(int id)
        {
            try
            {
                var offer = await unitOfWork.Offers.GetByIdAsync(id);
                if (offer == null)
                {
                    return false;
                }
                unitOfWork.Offers.Remove(offer);
                await unitOfWork.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
