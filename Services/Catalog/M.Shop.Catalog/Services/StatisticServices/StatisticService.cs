
using M.Shop.Catalog.Entities;
using M.Shop.Catalog.Settings;
using MongoDB.Driver;

namespace M.Shop.Catalog.Services.StatisticServices
{
	public class StatisticService : IStatisticService
	{
		private readonly IMongoCollection<Brand> _brandsCollection;
		private readonly IMongoCollection<Category> _categoryCollection;
		private readonly IMongoCollection<Contact> _contactCollection;
		private readonly IMongoCollection<Product> _productCollection;

		public StatisticService(IDatabaseSettings _databaseSettings)
		{
			var client=new MongoClient(_databaseSettings.ConnectionString);
			_brandsCollection = client.GetDatabase(_databaseSettings.DatabaseName).GetCollection<Brand>(_databaseSettings.BrandCollectionName);
			_categoryCollection = client.GetDatabase(_databaseSettings.DatabaseName).GetCollection<Category>(_databaseSettings.CategoryCollectionName);
			_contactCollection = client.GetDatabase(_databaseSettings.DatabaseName).GetCollection<Contact>(_databaseSettings.ContactCollectionName);
			_productCollection = client.GetDatabase(_databaseSettings.DatabaseName).GetCollection<Product>(_databaseSettings.ProductCollectionName);

		}

		public async Task<decimal> GetAvgProductPrice()
		{
			var filter = Builders<Product>.Filter.Empty;
			var result = await _productCollection.Find<Product>(filter).ToListAsync();
			decimal avgPrice = result.Average(x => x.ProductPrice);
			return avgPrice;

		}

		public async Task<long> GetBrandCount()
		{
			var filter = Builders<Brand>.Filter.Empty;
			long count = await _brandsCollection.CountDocumentsAsync(filter);
			return count;
		}

		public async Task<long> GetCategoryCount()
		{
			var filter=Builders<Category>.Filter.Empty;
			long count=await _categoryCollection.CountDocumentsAsync(filter);
			return count;
		}

		public async Task<long> GetContactCount()
		{
			var filter=Builders<Contact>.Filter.Empty;
			long count= await _contactCollection.CountDocumentsAsync(filter);
			return count;
		}

		public async Task<string> GetLastCreatedProductName()
		{
			var filter = Builders<Product>.Filter.Empty;
			var result = await _productCollection.Find<Product>(filter).ToListAsync();
			string ProductName=result.LastOrDefault().ProductName;
			return ProductName;
		}
	}
}
