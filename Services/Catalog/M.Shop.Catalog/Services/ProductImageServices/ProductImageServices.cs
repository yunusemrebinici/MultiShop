using AutoMapper;
using M.Shop.Catalog.Dtos.ProductImageDtos;
using M.Shop.Catalog.Entities;
using M.Shop.Catalog.Settings;
using MongoDB.Driver;

namespace M.Shop.Catalog.Services.ProductImageServices
{
	public class ProductImageServices : IProductImageServices
	{
		private readonly IMapper _mapper;
		private readonly IMongoCollection<ProductImage>_collection;

		public ProductImageServices(IMapper mapper,IDatabaseSettings databaseSettings)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
			_collection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
			_mapper = mapper;
		}

		public async Task CreateProductImageAsync(CreateProductImageDto ProductImageDto)
		{
			var value=_mapper.Map<ProductImage>(ProductImageDto);
			await _collection.InsertOneAsync(value);
		}

		public async Task DeleteProductImageAsync(string id)
		{
			await _collection.DeleteOneAsync(x => x.ProductImagesID == id);
		}

		public async Task<ResultProductImageDto> GetByIdProductImageAsync(string id)
		{
			var value = await _collection.Find(x => x.ProductID == id).FirstOrDefaultAsync();
			return _mapper.Map<ResultProductImageDto>(value);

		}

		public async Task<List<ResultProductImageDto>> GettAllProductImageAsync()
		{
			var values = await _collection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultProductImageDto>>(values);
		}

		public async Task UpdateProductImageAsync(UpdateProductImageDto ProductImageDto)
		{
			var value= _mapper.Map<ProductImage>(ProductImageDto);
			await _collection.FindOneAndReplaceAsync(x => x.ProductImagesID == ProductImageDto.ProductImagesID, value);
		}
	}
}
