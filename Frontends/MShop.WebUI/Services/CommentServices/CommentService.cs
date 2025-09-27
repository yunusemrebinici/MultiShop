using Frontends.DTO.CATALOG.CommentDTOS;

namespace MShop.WebUI.Services.CommentServices
{
	public class CommentService : ICommentService
	{
		private readonly HttpClient _httpClient;

		public CommentService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task ActiveCommentAsync(int id)
		{
			await _httpClient.GetAsync($"Comments/ActiveComment/{id}");
		}

		public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
		{
			await _httpClient.PostAsJsonAsync<CreateCommentDto>("Comments", createCommentDto);
		}

		public async Task DeleteCommentAsync(int id)
		{
			await _httpClient.DeleteAsync($"Comments/{id}");
		}

		public async Task<List<ResultCommentDto>> GetAllCommentAsync()
		{
			var values = await _httpClient.GetFromJsonAsync<List<ResultCommentDto>>("Comments");
			return values;
		}

		public async Task<ResultCommentDto> GetCommentAsync(string id)
		{
			var values = await _httpClient.GetFromJsonAsync<ResultCommentDto>($"Comments/{id}");
			return values;
		}

		public async Task<List<ResultCommentDto>> GetCommentsByProductIdAsync(string id)
		{
			var values = await _httpClient.GetFromJsonAsync<List<ResultCommentDto>>($"Comments/GetCommentsByProductIdAsync/{id}");
			return values;
		}

		public async Task PassiveCommentAsync(int id)
		{
			await _httpClient.GetAsync($"Comments/PassiveCommentAsync/{id}");
		}

		public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
		{
			await _httpClient.PutAsJsonAsync<UpdateCommentDto>("Comments", updateCommentDto);
		}
	}
}
