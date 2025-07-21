using M.Shop.Discount.Dtos;

namespace M.Shop.Discount.Services
{
	public interface IDiscountService
	{
		Task<List<ResultCouponDto>> GettAllCouponAsync();
		Task<ResultCouponDto> GettCouponByIdAsync(int id);
		Task CreateCouponAsync(CreateCouponDto couponDto);
		Task UpdateCouponAsync(UpdateCouponDto couponDto);
		Task DeleteCouponAsync(int id);
	}
}
