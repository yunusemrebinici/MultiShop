using AutoMapper;
using M.Shop.Catalog.Dtos.SpecialOfferDtos;
using M.Shop.Catalog.Entities;
using M.Shop.Catalog.Settings;
using MongoDB.Driver;

namespace M.Shop.Catalog.Services.SpecialOfferServices
{
	public class SpecialOfferServices : ISpecialOfferServices
	{
		private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;

		private readonly IMapper _mapper;

		public SpecialOfferServices(IMapper mapper, IDatabaseSettings _settings)
		{
			var client = new MongoClient(_settings.ConnectionString);
			var database = client.GetDatabase(_settings.SpecialOfferCollectionName);
			_specialOfferCollection = database.GetCollection<SpecialOffer>(_settings.SpecialOfferCollectionName);
			_mapper = mapper;
		}

		public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto SpecialOfferDto)
		{
			var values = _mapper.Map<SpecialOffer>(SpecialOfferDto);
			await _specialOfferCollection.InsertOneAsync(values);
		}

		public async Task DeleteSpecialOfferAsync(string id)
		{
			await _specialOfferCollection.DeleteOneAsync(x => x.SpecialOfferId == id);
		}

		public async Task<ResultSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
		{
			var value = await _specialOfferCollection.Find(x => x.SpecialOfferId == id).FirstOrDefaultAsync();
			return _mapper.Map<ResultSpecialOfferDto>(value);
		}

		public async Task<List<ResultSpecialOfferDto>> GettAllSpecialOfferAsync()
		{
			var values = await _specialOfferCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultSpecialOfferDto>>(values);
		}

		public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto SpecialOfferDto)
		{
			var update = _mapper.Map<SpecialOffer>(SpecialOfferDto);
			await _specialOfferCollection.FindOneAndReplaceAsync(x => x.SpecialOfferId == SpecialOfferDto.SpecialOfferId, update);
		}
	}
}
