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
		private readonly IMongoCollection<Category> _categories;

		public ProductServices(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database= client.GetDatabase(_databaseSettings.DatabaseName);
			_collection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
			_categories= database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
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

		public async Task<List<ResultProductWithCategoryNameDto>> GetAllProductWithCategoryNameAsync()
		{
			List<ResultProductWithCategoryNameDto> result = new List<ResultProductWithCategoryNameDto>();
			var products = await _collection.Find<Product>(x=>true).ToListAsync();
			var categoryies=  await _categories.Find<Category>(y=>true).ToListAsync();
		

			foreach (var item in products)
			{

				result.Add(new ResultProductWithCategoryNameDto()
				{
					ProductID = item.ProductID,
					CategoryName = categoryies.Where(x => x.CategoryID == item.CategoryID).Select(z => z.CategoryName).FirstOrDefault(),
					ProductDescription = item.ProductDescription,
					ProductImageUrl = item.ProductImageUrl,
					ProductName = item.ProductName,
					ProductPrice=item.ProductPrice,

				});
			}
			return result;
			
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
