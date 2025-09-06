using AutoMapper;
using M.Shop.Catalog.Dtos.BrandDtos;
using M.Shop.Catalog.Entities;
using M.Shop.Catalog.Settings;
using MongoDB.Driver;

namespace M.Shop.Catalog.Services.BrandServices
{
	public class BrandServices : IBrandServices
	{
		private readonly IMongoCollection<Brand> _brands;
		private readonly IMapper _mapper;

		public BrandServices(IMapper mapper,IDatabaseSettings settings)
		{
			var client= new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);
			_brands = database.GetCollection<Brand>(settings.BrandCollectionName);
			_mapper = mapper;
		}

		public async Task CreateBrandAsync(CreateBrandDto BrandDto)
		{
			var value=_mapper.Map<Brand>(BrandDto);
			await _brands.InsertOneAsync(value);
		}

		public async Task DeleteBrandAsync(string id)
		{
			await _brands.DeleteOneAsync(x=>x.BrandId==id);
		}

		public async Task<ResultBrandDto> GetByIdBrandAsync(string id)
		{
			var value = await _brands.Find(x => x.BrandId == id).FirstOrDefaultAsync();
		    return _mapper.Map<ResultBrandDto>(value);
		}

		public async Task<List<ResultBrandDto>> GettAllBrandAsync()
		{
			var values = await _brands.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultBrandDto>>(values);
		}

		public async Task UpdateBrandAsync(UpdateBrandDto BrandDto)
		{
			var update= _mapper.Map<Brand>(BrandDto);

			await _brands.FindOneAndReplaceAsync(x => x.BrandId == BrandDto.BrandId, update);
		}
	}
}
