using AutoMapper;
using M.Shop.Catalog.Dtos.FeatureProductDtos;
using M.Shop.Catalog.Entities;
using M.Shop.Catalog.Settings;
using MongoDB.Driver;

namespace M.Shop.Catalog.Services.FeatureProductServices
{
	public class FeatureProductServices : IFeatureProductServices
	{

		private readonly IMongoCollection<FeatureProduct> _featureProduct;
		private readonly IMapper _mapper;

		public FeatureProductServices(IMapper mapper,IDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);
			_featureProduct = database.GetCollection<FeatureProduct>(settings.FeatureProductCollectionName);
			_mapper = mapper;
		}

		public async Task CreateFeatureProductAsync(CreateFeatureProductDto FeatureProductDto)
		{
			var values= _mapper.Map<FeatureProduct>(FeatureProductDto);
			await _featureProduct.InsertOneAsync(values);
		}

		public async Task DeleteFeatureProductAsync(string id)
		{
			await _featureProduct.DeleteOneAsync(x=>x.FeatureProductId==id);
		}

		public async Task<ResultFeatureProductDto> GetByIdFeatureProductAsync(string id)
		{
			var value = await _featureProduct.Find<FeatureProduct>(x => x.FeatureProductId == id).FirstOrDefaultAsync();
			return _mapper.Map<ResultFeatureProductDto>(value);
		}

		public async Task<List<ResultFeatureProductDto>> GettAllFeatureProductAsync()
		{
			var values = await _featureProduct.Find(x=> true).ToListAsync();
			return _mapper.Map<List<ResultFeatureProductDto>>(values);
		}

		public async Task UpdateFeatureProductAsync(UpdateFeatureProductDto FeatureProductDto)
		{
			var update = _mapper.Map<FeatureProduct>(FeatureProductDto);
			await _featureProduct.FindOneAndReplaceAsync(x => x.FeatureProductId == FeatureProductDto.FeatureProductId, update);
		}
	}
}
