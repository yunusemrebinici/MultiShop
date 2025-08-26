namespace Basket.WebApi.LoginServices
{
	public class LoginService : ILoginService
	{
		private readonly IHttpContextAccessor _HttpcontextAccessor;

		public LoginService(IHttpContextAccessor httpcontextAccessor)
		{
			_HttpcontextAccessor = httpcontextAccessor;
		}

		public string GetUserId => _HttpcontextAccessor.HttpContext.User.FindFirst("sub").Value;

	}
}
