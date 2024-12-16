using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Core.Repositories.IRepositories
{
    public interface IReviewRepos : IRepository<Review>
    {
        Task<List<ReviewDTO>?> GetAll();
        Task<List<ReviewDTO>> GetReviewsByUser(int userId);
        Task<List<ReviewDTO>> GetReviewsByItem(int itemId);
    }
}
