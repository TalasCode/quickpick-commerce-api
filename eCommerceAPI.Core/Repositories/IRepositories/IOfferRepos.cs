using eCommerceAPI.Core.DTO;
using eCommerceAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Core.Repositories.IRepositories
{
    public interface IOfferRepos : IRepository<Offer>
    {
        Task<List<OfferDTO>?> GetAll();
        Task<List<OfferDTO>?> GetOfferByCategory(int categoryId);
        Task<List<OfferDTO>?> GetOfferByBrand(int brandId);
    }
}
