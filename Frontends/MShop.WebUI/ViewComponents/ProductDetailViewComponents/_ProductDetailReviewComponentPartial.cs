using Frontends.DTO.CATALOG.CommentDTOS;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CommentServices;
using Newtonsoft.Json;

namespace MShop.WebUI.ViewComponents.ProductDetailViewComponents
{
	public class _ProductDetailReviewComponentPartial:ViewComponent
	{
		private readonly ICommentService _commentService;

		public _ProductDetailReviewComponentPartial(ICommentService commentService)
		{
			_commentService = commentService;
		}

		public async Task<IViewComponentResult> InvokeAsync(string id)
		{
			var values= await _commentService.GetCommentsByProductIdAsync(id);
			return View(values);
		}
	}
}
