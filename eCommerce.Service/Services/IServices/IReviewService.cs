using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Services.IServices
{
    public interface IReviewService
    {
        Task<List<ReviewDTO>?> GetAllReviews();
        Task<Review?> GetReviewById(int id);
        Task<List<ReviewDTO>?> GetReviewsByItem(int itemId);
        Task<List<ReviewDTO>?> GetReviewByUser(int userId);
        Task<Review> AddReview(Review review);
        Task<Review> UpdateReview(Review review);
        Task<bool> DeleteReview(int id);
    }
}
