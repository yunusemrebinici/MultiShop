using Frontends.DTO.CATALOG.CommentDTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CommentServices;
using Newtonsoft.Json;
using System.Text;

namespace MShop.WebUI.Areas.Admin.Controllers
{
	[Authorize]
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]")]
	public class CommentController : Controller
	{
		private readonly ICommentService _commentService;

		public CommentController(ICommentService commentService)
		{
			_commentService = commentService;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _commentService.GetAllCommentAsync();
			return View(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult>CommentByProduct(string id)
		{
			var values= await _commentService.GetCommentsByProductIdAsync(id);
			return View(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> UpdateComment(string id)
		{
			var values = await _commentService.GetCommentAsync(id);


			return View(new UpdateCommentDto()
			{
				ReviewID=values.ReviewID,
				ProductId=values.ProductId,
				Status=values.Status,
				Comments=values.Comments,
				Date = values.date,
				ImageUrl=values.ImageUrl,
				Name=values.Name,
				Point = values.Point
				
			});
		}

		[HttpPost("{id}")]
		public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
		{
			await _commentService.UpdateCommentAsync(updateCommentDto);
			return RedirectToAction("Index");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> DeleteComment(int id)
		{
			await _commentService.DeleteCommentAsync(id);
			return View();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> ActiveCommentStatus(int id)
		{

			await _commentService.ActiveCommentAsync(id);
			return View();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> PassiveCommentStatus(int id)
		{

			await _commentService.PassiveCommentAsync(id);
			return View();
		}
	}
}
