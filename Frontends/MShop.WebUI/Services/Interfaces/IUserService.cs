using MShop.WebUI.Models;

namespace MShop.WebUI.Services.Interfaces
{
	public interface IUserService
	{
		public Task<UserDetailViewModel> GetUserInfo();
	}
}
