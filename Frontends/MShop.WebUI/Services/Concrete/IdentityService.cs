using Frontends.DTO.LOGİN;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MShop.WebUI.Services.Interfaces;
using MShop.WebUI.Settings;
using System.Security.Claims;

namespace MShop.WebUI.Services.Concrete
{
	public class IdentityService : IIdentityService
	{

		private readonly HttpClient _httpClient;
		private readonly IHttpContextAccessor _contextAccessor;
		private readonly ClientSettings _clientSettings;
		private readonly ServiceApiSettings _serviceApiSettings;

		public IdentityService(HttpClient httpClient, IHttpContextAccessor contextAccessor,IOptions<ClientSettings> options, IOptions<ServiceApiSettings> serviceApiSettings)
		{
			_clientSettings = options.Value;
			_httpClient = httpClient;
			_contextAccessor = contextAccessor;
			_serviceApiSettings = serviceApiSettings.Value;
		}

		public async Task<bool> GetRefreshToken()
		{
			var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
			{
				Address = _serviceApiSettings.IdentityServerUrl,
				Policy = new DiscoveryPolicy
				{
					RequireHttps = false,
				}

			});



			var Refreshtoken = await _contextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

			RefreshTokenRequest refreshTokenRequest = new()
			{
				ClientId=_clientSettings.MultiShopManagerClient.ClientId,
				ClientSecret=_clientSettings.MultiShopManagerClient.ClientSecret,
				RefreshToken=Refreshtoken,
				Address=discoveryEndPoint.TokenEndpoint
			};

			var token= await _httpClient.RequestRefreshTokenAsync(refreshTokenRequest);

			var authentication = new List<AuthenticationToken>()
			{
				new AuthenticationToken
				{
					Name=OpenIdConnectParameterNames.AccessToken,
					Value=token.AccessToken
				},
				new AuthenticationToken
				{
					Name=OpenIdConnectParameterNames.RefreshToken,
					Value=token.RefreshToken
				},
				new AuthenticationToken
				{
					Name=OpenIdConnectParameterNames.ExpiresIn,
					Value=DateTime.Now.AddDays(token.ExpiresIn).ToString()
				}
			};


			var result = await _contextAccessor.HttpContext.AuthenticateAsync();
			
			var properties= result.Properties;

			properties.StoreTokens(authentication);

			await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.Principal, properties);

			return true;
		}

		public async Task<bool> SignIn(SignUpDto signUpDto)
		{
			var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
			{
				Address= _serviceApiSettings.IdentityServerUrl,
				Policy=new DiscoveryPolicy {
				RequireHttps=false,
				}

			});

			var passwordTokenRequest = new PasswordTokenRequest
			{
				ClientId = _clientSettings.MultiShopManagerClient.ClientId,
				ClientSecret = _clientSettings.MultiShopManagerClient.ClientSecret,
				UserName = signUpDto.UserName,
				Password = signUpDto.Password,
				Address = discoveryEndPoint.TokenEndpoint

			};

			var token= await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);

			var userInfoRequest = new UserInfoRequest
			{
				Token = token.AccessToken,
				Address = discoveryEndPoint.UserInfoEndpoint,


			};
			var userValues = await _httpClient.GetUserInfoAsync(userInfoRequest);

			ClaimsIdentity claimsIdentity = new ClaimsIdentity(userValues.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");
			ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
			var authenticationProperties = new AuthenticationProperties();
			authenticationProperties.StoreTokens(new List<AuthenticationToken>()
			{
				new AuthenticationToken
				{
					Name=OpenIdConnectParameterNames.AccessToken,
					Value=token.AccessToken
				},
				new AuthenticationToken
				{
					Name=OpenIdConnectParameterNames.RefreshToken,
					Value=token.RefreshToken
				},
				new AuthenticationToken
				{
					Name=OpenIdConnectParameterNames.ExpiresIn,
					Value=DateTime.Now.AddDays(token.ExpiresIn).ToString()
				}

			});
			authenticationProperties.IsPersistent = false;

			await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);

			return true;
		}
	}
}
