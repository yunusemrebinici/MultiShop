using AutoMapper;
using M.Shop.Catalog.Dtos.OfferDiscountDtos;
using M.Shop.Catalog.Entities;
using M.Shop.Catalog.Settings;
using MongoDB.Driver;

namespace M.Shop.Catalog.Services.OfferDiscountServices
{
	public class OfferDiscountServices : IOfferDiscountServices
	{
		private readonly IMongoCollection<OfferDiscount> _offerDiscount;
		private readonly IMapper _mapper;

		public OfferDiscountServices(IMapper mapper,IDatabaseSettings settings)
		{
			var client= new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);
			_offerDiscount = database.GetCollection<OfferDiscount>(settings.OfferDiscountCollectionName);
			_mapper = mapper;
		}


		public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto OfferDiscountDto)
		{
			var value= _mapper.Map<OfferDiscount>(OfferDiscountDto);
			await _offerDiscount.InsertOneAsync(value);
		}

		public async Task DeleteOfferDiscountAsync(string id)
		{
			await _offerDiscount.DeleteOneAsync(x=>x.OfferDiscountId==id);
		}

		public async Task<ResultOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
		{
			var value = await _offerDiscount.Find(x => x.OfferDiscountId == id).FirstOrDefaultAsync();
			return _mapper.Map<ResultOfferDiscountDto>(value);
		}

		public async Task<List<ResultOfferDiscountDto>> GettAllOfferDiscountAsync()
		{
			var values = await _offerDiscount.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultOfferDiscountDto>>(values);
		}

		public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto OfferDiscountDto)
		{
			var update = _mapper.Map<OfferDiscount>(OfferDiscountDto);
			await _offerDiscount.FindOneAndReplaceAsync(x => x.OfferDiscountId == OfferDiscountDto.OfferDiscountId, update);
		}
	}
}
