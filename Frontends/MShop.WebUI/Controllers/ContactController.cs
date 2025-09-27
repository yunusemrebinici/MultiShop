using Frontends.DTO.CATALOG.ContactDTOS;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CatalogServices.ContactServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MShop.WebUI.Controllers
{
	public class ContactController : Controller
	{
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}

		public IActionResult Index()
		{
			return View();
		}


		[HttpGet]
		public async Task<PartialViewResult> CreateContact()
		{
			return PartialView();
		}

		[HttpPost]
		public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
		{
			createContactDto.MessageTime= DateTime.Now;

			await _contactService.CreateContactAsync(createContactDto);

			return View("Index","Contact");
		}
	}
}
