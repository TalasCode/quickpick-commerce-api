using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using eCommerceAPI.Core.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Core.Repositories
{
    public class ReviewRepos(DbContext context) : Repository<Review>(context) , IReviewRepos
    {
        private DatabaseServerContext databaseServerContext => (DatabaseServerContext)Context;

        public async Task<List<ReviewDTO>?> GetAll()
        {
            return await databaseServerContext.Reviews.Select(r => new ReviewDTO
            {
                Id = r.Id,
                UserId = r.UserId,
                ItemId = r.ItemId,
                Rating = r.Rating,
                Comment = r.Comment,
            }).ToListAsync();
        }
        public async Task<List<ReviewDTO>> GetReviewsByUser(int userId)
        {
            return await databaseServerContext.Reviews.Where(r => r.UserId == userId)
                .Select(r => new ReviewDTO
                {
                    Id = r.Id,
                    UserId = r.UserId,
                    ItemId = r.ItemId,
                    Rating = r.Rating,
                    Comment = r.Comment,
                }).ToListAsync();
        }
        public async Task<List<ReviewDTO>> GetReviewsByItem(int itemId)
        {
            return await databaseServerContext.Reviews.Where(r => r.ItemId == itemId)
              .Select(r => new ReviewDTO
              {
                  Id = r.Id,
                  UserId = r.UserId,
                  ItemId = r.ItemId,
                  Rating = r.Rating,
                  Comment = r.Comment,
              }).ToListAsync();
        }
    }
}
