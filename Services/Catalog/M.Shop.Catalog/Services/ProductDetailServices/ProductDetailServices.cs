using AutoMapper;
using M.Shop.Catalog.Dtos.ProductDetailDtos;
using M.Shop.Catalog.Entities;
using M.Shop.Catalog.Settings;
using MongoDB.Driver;

namespace M.Shop.Catalog.Services.ProductDetailServices
{
	public class ProductDetailServices : IProductDetailServices

	{
		private readonly IMapper _mapper;
		private readonly IMongoCollection<ProductDetail> _collection;

		public ProductDetailServices(IMapper mapper,IDatabaseSettings _databaseSettings)
		{
			var client= new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_collection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
			_mapper = mapper;
		}

		public async Task CreateProductDetailAsync(CreateProductDetailDto ProductDetailDto)
		{
			var value= _mapper.Map<ProductDetail>(ProductDetailDto);
			await _collection.InsertOneAsync(value);
		}

		public async Task DeleteProductDetailAsync(string id)
		{
			await _collection.DeleteOneAsync(x => x.ProductDetailID == id);
		}

		public async Task<ResultProductDetailDto> GetByIdProductDetailAsync(string id)
		{
			var value = await _collection.Find<ProductDetail>(x => x.ProductDetailID == id).FirstOrDefaultAsync();
			return _mapper.Map<ResultProductDetailDto>(value);

		}

		public async Task<List<ResultProductDetailDto>> GettAllProductDetailAsync()
		{
			var values = await _collection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultProductDetailDto>>(values);
		}

		public async Task UpdateProductDetailAsync(UpdateProductDetailDto ProductDetailDto)
		{
			var value = _mapper.Map<ProductDetail>(ProductDetailDto);
			await _collection.FindOneAndReplaceAsync(x => x.ProductDetailID == ProductDetailDto.ProductID, value);
		}
	}
}
