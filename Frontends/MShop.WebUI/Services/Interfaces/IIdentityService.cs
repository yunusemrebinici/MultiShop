using Frontends.DTO.LOGİN;

namespace MShop.WebUI.Services.Interfaces
{
	public interface IIdentityService
	{
		Task<bool> SignIn(SignUpDto signUpDto);

		Task<bool> GetRefreshToken();
	}
}
