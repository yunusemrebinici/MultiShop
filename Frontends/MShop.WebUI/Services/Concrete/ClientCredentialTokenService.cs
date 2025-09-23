using IdentityModel.Client;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using MShop.WebUI.Services.Interfaces;
using MShop.WebUI.Settings;

namespace MShop.WebUI.Services.Concrete
{
	public class ClientCredentialTokenService: IClientCredentialTokenService
	{
		private readonly ServiceApiSettings _settings;
		private readonly HttpClient _httpClient;
		private readonly IMemoryCache _cache;
		private readonly ClientSettings _clientSettings;

		public ClientCredentialTokenService(IOptions<ServiceApiSettings> settings, HttpClient httpClient, IMemoryCache cache, IOptions<ClientSettings> clientSettings)
		{
			_settings = settings.Value;
			_httpClient = httpClient;
			_cache = cache;
			_clientSettings = clientSettings.Value;
		}

		public async Task<string> GetToken()

		{

			if (_cache.TryGetValue("multishoptoken", out string cachedToken))

			{

				return cachedToken;

			}

			var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest

			{

				Address = _settings.IdentityServerUrl,

				Policy = new DiscoveryPolicy

				{

					RequireHttps = false

				}

			});

			var clientCredentialTokenRequest = new ClientCredentialsTokenRequest

			{

				ClientId = _clientSettings.MultiShopVisitorClient.ClientId,

				ClientSecret = _clientSettings.MultiShopVisitorClient.ClientSecret,

				Address = discoveryEndPoint.TokenEndpoint

			};

			var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);

			if (tokenResponse.IsError)

			{

				throw new Exception("Token alınamadı: " + tokenResponse.ErrorDescription);

			}

			_cache.Set("multishoptoken", tokenResponse.AccessToken, TimeSpan.FromSeconds(tokenResponse.ExpiresIn));

			return tokenResponse.AccessToken;

		}

	}

}
	

