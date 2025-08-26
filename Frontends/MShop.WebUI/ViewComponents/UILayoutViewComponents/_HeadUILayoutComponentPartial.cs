using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace MShop.WebUI.ViewComponents.UILayoutViewComponents
{
	public class _HeadUILayoutComponentPartial:ViewComponent
	{
		public async Task <IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
