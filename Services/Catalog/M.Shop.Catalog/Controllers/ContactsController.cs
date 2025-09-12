using M.Shop.Catalog.Dtos.ContactDtos;
using M.Shop.Catalog.Services.ContactServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M.Shop.Catalog.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly IContactService _ContactService;

		public ContactsController(IContactService ContactService)
		{
			_ContactService = ContactService;
		}

		[HttpGet]
		public async Task<IActionResult> ContactList()
		{
			return Ok(await _ContactService.GettAllContactAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetContact(string id)
		{
			return Ok(await _ContactService.GetContactAsync(id));
		}

		[HttpPost]
		public async Task<IActionResult> CreateContact(CreateContactDto ContactDto)
		{
			await _ContactService.CreateContactAsync(ContactDto);
			return Ok("Ekleme Başarılı");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteContact(string id)
		{
			await _ContactService.DeleteContactAsync(id);
			return Ok("Silme Başarılı");
		}
	}
}
