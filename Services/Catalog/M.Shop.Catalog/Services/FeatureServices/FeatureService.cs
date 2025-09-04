using AutoMapper;
using M.Shop.Catalog.Dtos.FeatureDtos;
using M.Shop.Catalog.Entities;
using M.Shop.Catalog.Settings;
using MongoDB.Driver;

namespace M.Shop.Catalog.Services.FeatureServices
{
	public class FeatureService : IFeatureServices
	{
		private readonly IMongoCollection<Feature> _features;
		private IMapper _mapper;

		public FeatureService(IMapper mapper,IDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);
			_features = database.GetCollection<Feature>(settings.FeatureCollectionName);
			_mapper = mapper;
		}

		public async Task CreateFeatureAsync(CreateFeatureDto FeatureDto)
		{
		    var value = _mapper.Map<Feature>(FeatureDto);
			await _features.InsertOneAsync(value);
		}

		public async Task DeleteFeatureAsync(string id)
		{
			await _features.DeleteOneAsync(x=>x.FeatureId==id);
		}

		public async Task<ResultFeatureDto> GetByIdFeatureAsync(string id)
		{
			var value=await _features.Find(x=>x.FeatureId==id).ToListAsync();
			return _mapper.Map<ResultFeatureDto>(value);
		}

		public async Task<List<ResultFeatureDto>> GettAllFeatureAsync()
		{
			var values= await _features.Find(x=> true).ToListAsync();
			return _mapper.Map<List<ResultFeatureDto>>(values);
		}

		public async Task UpdateFeatureAsync(UpdateFeatureDto FeatureDto)
		{
			var update= _mapper.Map<Feature>(FeatureDto);
			await _features.FindOneAndReplaceAsync(x=>x.FeatureId==FeatureDto.FeatureId,update);
		}
	}
}
