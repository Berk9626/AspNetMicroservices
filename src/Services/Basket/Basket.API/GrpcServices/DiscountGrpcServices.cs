using Discount.Grpc.Protos;
using System.Threading.Tasks;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcServices
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoService;

        //Sadece _discountProtoService getirdik. Bu da client application'dan geliyor 
        //As you can see that this time we are not inherit from the protocell because this is not a replication. This is the client for the discounted services is why we didn't inherit.
        public DiscountGrpcServices(DiscountProtoService.DiscountProtoServiceClient discountProtoService)
        {
            _discountProtoService = discountProtoService;
        }

        public async Task<CouponModel> GetDiscount(string productName)
        {
            var discountRequest = new GetDiscountRequest { ProductName = productName }; 
           
            return await _discountProtoService.GetDiscountAsync(discountRequest);
        }
    }
}
