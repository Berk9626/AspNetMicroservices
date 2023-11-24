using Discount.Grpc.Entities;
using System.Threading.Tasks;

namespace Discount.Grpc.Repositories
{
    public interface IDiscountRepositories
    {
        Task<Coupon> GetDiscount(string productName);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool> CreateDiscount(Coupon coupon);
        Task<bool> DeleteDiscount(string productName);


    }
}
