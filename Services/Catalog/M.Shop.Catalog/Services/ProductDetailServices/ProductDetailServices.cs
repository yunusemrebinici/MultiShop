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
		private readonly IMongoCollection<Product> _productCollection;

		public ProductDetailServices(IMapper mapper,IDatabaseSettings _databaseSettings)
		{
			var client= new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_collection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
			_productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
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

		public async Task<GetProductDetailDescriptionDto> GetProductDetailDescription(string id)
		{
			var product = await _productCollection.Find(x => x.ProductID == id).FirstOrDefaultAsync();
			GetProductDetailDescriptionDto dto = new GetProductDetailDescriptionDto();
			var value = await _collection.Find(x => x.ProductID == id).FirstOrDefaultAsync();
			dto.ProductDetailDescription=value.ProductDescription;
			return dto;

		}

		public async Task<GetProductDetailInformationDto> GetProductDetailInformation(string id)
		{
			var product = await _productCollection.Find(x => x.ProductID == id).FirstOrDefaultAsync();
			GetProductDetailInformationDto dto = new GetProductDetailInformationDto();
			var value = await _collection.Find(x => x.ProductID == id).FirstOrDefaultAsync();
			dto.ProductInformation = value.ProductInformation;
			return dto;
		}

		public async Task<GetProductDetailWithProductNameDto> GetProductDetailWithProductName(string id)
		{
			var product = await _productCollection.Find(x => x.ProductID == id).FirstOrDefaultAsync();
			GetProductDetailWithProductNameDto dto = new GetProductDetailWithProductNameDto();
			var value= await _collection.Find(x => x.ProductID == id).FirstOrDefaultAsync();
			dto.ProductName = product.ProductName;
			dto.ProductID=value.ProductID;
			dto.ProductDetailID=value.ProductDetailID;
			dto.Price=product.ProductPrice;
			dto.Description=product.ProductDescription;

			return dto;

		}

		public async Task<List<ResultProductDetailDto>> GettAllProductDetailAsync()
		{
			var values = await _collection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultProductDetailDto>>(values);
		}

		public async Task UpdateProductDetailAsync(UpdateProductDetailDto ProductDetailDto)
		{
			var value = _mapper.Map<ProductDetail>(ProductDetailDto);
			await _collection.FindOneAndReplaceAsync(x => x.ProductDetailID == ProductDetailDto.ProductDetailID, value);
		}
	}
}
