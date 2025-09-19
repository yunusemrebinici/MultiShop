using MShop.WebUI.Models;
using MShop.WebUI.Services.Interfaces;

namespace MShop.WebUI.Services.Concrete
{
	public class UserService : IUserService
	{
		private readonly HttpClient _httpclient;

		public UserService(HttpClient httpclient)
		{
			_httpclient = httpclient;
		}

		public async Task<UserDetailViewModel> GetUserInfo()
		{
			return await _httpclient.GetFromJsonAsync<UserDetailViewModel>("/api/AppUsers/GetUser");
		}
	}
}
