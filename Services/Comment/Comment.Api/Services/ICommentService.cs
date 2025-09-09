using Comment.Api.CommentDTOS;

namespace Comment.Api.Services
{
	public interface ICommentService
	{
		Task<ResultCommentDto> GetCommentAsync(string id);
		Task<List<ResultCommentDto>> GetAllCommentAsync();
		Task CreateCommentAsync(CreateCommentDto createCommentDto);
		Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
		Task DeleteCommentAsync(int id);
		Task ActiveCommentAsync(int id);
		Task PassiveCommentAsync(int id);


	}
}
