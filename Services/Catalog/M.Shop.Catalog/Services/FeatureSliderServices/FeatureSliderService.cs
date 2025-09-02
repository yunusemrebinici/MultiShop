using AutoMapper;
using M.Shop.Catalog.Dtos.FeatureSliderDtos;
using M.Shop.Catalog.Entities;
using M.Shop.Catalog.Settings;
using MongoDB.Driver;

namespace M.Shop.Catalog.Services.FeatureSliderServices
{
	public class FeatureSliderService : IFeatureSliderService
	{
		
		private readonly IMongoCollection<FeatureSlider> _features;
		private readonly IMapper _mapper;
		
		public FeatureSliderService(IDatabaseSettings _settings, IMapper mapper)
		{
			var client = new MongoClient(_settings.ConnectionString);
			var database = client.GetDatabase(_settings.DatabaseName);
			_features = database.GetCollection<FeatureSlider>(_settings.FeatureSliderCollectionName);
			_mapper = mapper;
		}

		public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
		{
			createFeatureSliderDto.Featured = false;
			var values = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
			await _features.InsertOneAsync(values);
		}

		public async Task DeleteFeatureSliderAsync(string id)
		{
			await _features.DeleteOneAsync(x=>x.FeatureSliderId==id);
		}

		public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync()
		{
			 var values = await _features.Find(x=> true).ToListAsync();
			 return _mapper.Map<List<ResultFeatureSliderDto>>(values);
		}

		public async Task<ResultFeatureSliderDto> GetFeatureSliderByIdAsync(string id)
		{
			var value = await _features.Find<FeatureSlider>(x=>x.FeatureSliderId==id).FirstOrDefaultAsync();
			return _mapper.Map<ResultFeatureSliderDto>(value);
		}

		public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
		{
			var update = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
			await _features.FindOneAndReplaceAsync(x=>x.FeatureSliderId==updateFeatureSliderDto.FeatureSliderId, update);
		}
	}
}
