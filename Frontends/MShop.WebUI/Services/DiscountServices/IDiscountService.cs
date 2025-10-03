using Frontends.DTO.DİSCOUNT;

namespace MShop.WebUI.Services.DiscountServices
{
	public interface IDiscountService
	{
		Task<List<ResultCouponDto>> GettAllCouponAsync();
		Task<ResultCouponDto> GettCouponByIdAsync(int id);
		Task CreateCouponAsync(CreateCouponDto couponDto);
		Task UpdateCouponAsync(UpdateCouponDto couponDto);
		Task DeleteCouponAsync(int id);
		Task<int> GetCouponRate(string couponCode);
	}
}
