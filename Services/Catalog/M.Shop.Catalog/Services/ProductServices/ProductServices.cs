using AutoMapper;
using M.Shop.Catalog.Dtos.ProductDtos;
using M.Shop.Catalog.Entities;
using M.Shop.Catalog.Settings;
using MongoDB.Driver;

namespace M.Shop.Catalog.Services.ProductServices
{
	public class ProductServices : IProductServices
	{
		private readonly IMapper _mapper;
		private readonly IMongoCollection<Product> _collection;

		public ProductServices(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database= client.GetDatabase(_databaseSettings.DatabaseName);
			_collection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
			_mapper = mapper;
		}

	

		public async Task CreateProductAsync(CreateProductDto ProductDto)
		{
			var value=_mapper.Map<Product>(ProductDto);
			await _collection.InsertOneAsync(value);
		}

		public async Task DeleteProductAsync(string id)
		{
		     await _collection.DeleteOneAsync(x=>x.ProductID==id);
		}

		public async Task<ResultProductDto> GetByIdProductAsync(string id)
		{
			var value = await _collection.Find<Product>(x => x.ProductID == id).FirstOrDefaultAsync();
			return _mapper.Map<ResultProductDto>(value);
		}

		public async Task<List<ResultProductDto>> GettAllProductAsync()
		{
		     var values = await _collection.Find(x=>true).ToListAsync();
			return _mapper.Map<List<ResultProductDto>>(values);
		}

		public async Task UpdateProductAsync(UpdateProductDto ProductDto)
		{
			var value= _mapper.Map<Product>(ProductDto);
			await _collection.FindOneAndReplaceAsync(x => x.ProductID == ProductDto.ProductID, value);
		}
	}
}
