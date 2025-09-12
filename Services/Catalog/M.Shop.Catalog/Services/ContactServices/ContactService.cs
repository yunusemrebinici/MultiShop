using AutoMapper;
using M.Shop.Catalog.Dtos.ContactDtos;
using M.Shop.Catalog.Entities;
using M.Shop.Catalog.Settings;
using MongoDB.Driver;

namespace M.Shop.Catalog.Services.ContactServices
{
	public class ContactService : IContactService
	{
		private readonly IMongoCollection<Contact> _contacts;
		private readonly IMapper _mapper;

		public ContactService(IMapper mapper ,IDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var dataBase = client.GetDatabase(settings.DatabaseName);
			_contacts = dataBase.GetCollection<Contact>(settings.ContactCollectionName);
			_mapper = mapper;
		}

		public async Task CreateContactAsync(CreateContactDto ContactProductDto)
		{
			await _contacts.InsertOneAsync(_mapper.Map<Contact>(ContactProductDto));
		}

		public async Task DeleteContactAsync(string id)
		{
			await _contacts.DeleteOneAsync(x => x.ContactId == id);
		}

		public async Task<List<ResultContactDto>> GettAllContactAsync()
		{
			var values = await _contacts.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultContactDto>>(values);
		}
	}
}
