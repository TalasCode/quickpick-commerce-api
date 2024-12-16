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
    public class ReviewService(IUnitOfWork unitOfWork):IReviewService
    {
       public async Task<List<ReviewDTO>?> GetAllReviews()
        {
            try
            {
                var reviews = await unitOfWork.Reviews.GetAll();
                return reviews;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
       public async Task<Review?> GetReviewById(int id)
        {
            try
            {
                var review = await unitOfWork.Reviews.GetByIdAsync(id);
                return review;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
       public async Task<List<ReviewDTO>?> GetReviewsByItem(int itemId)
        {
            try
            {
                var reviews = await unitOfWork.Reviews.GetReviewsByItem(itemId);
                return reviews;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
       public async Task<List<ReviewDTO>?> GetReviewByUser(int userId)
        {
            try
            {
                var reviews = await unitOfWork.Reviews.GetReviewsByUser(userId);
                return reviews;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
       public async Task<Review> AddReview(Review review)
        {
            try
            {
                await unitOfWork.Reviews.AddAsync(review);
                return review;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
       public async  Task<Review> UpdateReview(Review review)
        {
            try
            {

                await unitOfWork.Reviews.UpdateAsync(review);
                await unitOfWork.CommitAsync();
                return review;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
       public async Task<bool> DeleteReview(int id)
        {
            try
            {
                var review = await unitOfWork.Reviews.GetByIdAsync(id);
                if (review == null)
                {
                    return false;
                }
                unitOfWork.Reviews.Remove(review);
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
