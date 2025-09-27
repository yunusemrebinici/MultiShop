
using Frontends.DTO.CATALOG.ContactDTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CatalogServices.ContactServices;
using Newtonsoft.Json;

namespace MShop.WebUI.Areas.Admin.Controllers
{
	[Authorize]
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]")]
	public class ContactController : Controller
	{
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}

		public async Task<IActionResult> Index()
		{
			var values= await _contactService.GettAllContactAsync();
			return View(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> ContactDetail(string id)
		{
			var values = await _contactService.GetContactAsync(id);

			return View(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> DeleteContact(string id)
		{
			await _contactService.DeleteContactAsync(id);
			return RedirectToAction("Index");
		}
	}
}
