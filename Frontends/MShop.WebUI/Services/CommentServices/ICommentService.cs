using Frontends.DTO.CATALOG.CommentDTOS;

namespace MShop.WebUI.Services.CommentServices
{
	public interface ICommentService
	{
		Task<ResultCommentDto> GetCommentAsync(string id);
		Task<List<ResultCommentDto>> GetCommentsByProductIdAsync(string id);
		Task<List<ResultCommentDto>> GetAllCommentAsync();
		Task CreateCommentAsync(CreateCommentDto createCommentDto);
		Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
		Task DeleteCommentAsync(int id);
		Task ActiveCommentAsync(int id);
		Task PassiveCommentAsync(int id);
	}
}
