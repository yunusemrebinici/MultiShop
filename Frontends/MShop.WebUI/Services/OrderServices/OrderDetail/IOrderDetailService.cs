using Frontends.DTO.ORDER.OrderDetail;

namespace MShop.WebUI.Services.OrderServices.OrderDetail
{
	public interface IOrderDetailService
	{
		Task CreateOrderDetail(CreateOrderDetailDto createOrderDetail);
	}
}
