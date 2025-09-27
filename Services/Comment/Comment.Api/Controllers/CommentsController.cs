using Comment.Api.CommentDTOS;
using Comment.Api.Concrete;
using Comment.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Comment.Api.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CommentsController : ControllerBase
	{
		private readonly ICommentService _commentService;

		public CommentsController(ICommentService commentService)
		{
			_commentService = commentService;
		}

		[HttpGet]
		public async Task<IActionResult> AllComments()
		{
			return Ok(await _commentService.GetAllCommentAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult>GetComment(string id)
		{
			return Ok(await _commentService.GetCommentAsync(id));
		}

		[HttpGet("GetCommentsByProductId/{id}")]
		public async Task<IActionResult> GetCommentsByProductId(string id)
		{
			return Ok(await _commentService.GetCommentsByProductIdAsync(id));
		}

		[HttpPost]
		public async Task<IActionResult>CreateComment(CreateCommentDto createCommentDto)
		{
			await _commentService.CreateCommentAsync(createCommentDto);
			return Ok("Ekleme Başarılı");
		}

		[HttpPut]
		public async Task <IActionResult>UpdateComment(UpdateCommentDto updateCommentDto)
		{
			await _commentService.UpdateCommentAsync(updateCommentDto);
			return Ok("Güncelleme Başarılı");
		}

		[HttpGet("ActiveComment/{id}")]
		public async Task<IActionResult>ActiveComment(int id)
		{
			await _commentService.ActiveCommentAsync(id);
			return Ok("İşlem Başarılı");
		}

		[HttpGet("PassiveComment/{id}")]
		public async Task<IActionResult> PassiveComment(int id)
		{
			await _commentService.PassiveCommentAsync(id);
			return Ok("İşlem Başarılı");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult>DeleteComment(int id)
		{
			await _commentService.DeleteCommentAsync(id);
			return Ok("Silme Başarılı");
		}
	}
}
