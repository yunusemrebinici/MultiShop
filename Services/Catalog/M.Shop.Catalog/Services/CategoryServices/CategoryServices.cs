using AutoMapper;
using M.Shop.Catalog.Dtos.CategoryDtos;
using M.Shop.Catalog.Entities;
using M.Shop.Catalog.Settings;
using MongoDB.Driver;

namespace M.Shop.Catalog.Services.CategoryServices
{
	public class CategoryServices : ICategoryService
	{
		private readonly IMongoCollection<Category> _categoryCollection;
		private readonly IMapper _mapper;

		public CategoryServices(IMapper mapper,IDatabaseSettings _databaseSettings)
		{
			var client =new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
			_mapper = mapper;
		}

		public async Task CreateCategoryAsync(CreateCategoryDto categoryDto)
		{
			var value= _mapper.Map<Category>(categoryDto);
			await _categoryCollection.InsertOneAsync(value);
		}

		public async Task DeleteCategoryAsync(string id)
		{
			await _categoryCollection.DeleteOneAsync(x=>x.CategoryID==id);
		}

		public async Task<ResultCategoryDto> GetByIdCategoryAsync(string id)
		{
			var values= await _categoryCollection.Find<Category>(x=>x.CategoryID==id).FirstOrDefaultAsync();
			return _mapper.Map<ResultCategoryDto>(values);
		}

		public async Task<List<ResultCategoryDto>> GettAllCategoryAsync()
		{
			var values = await _categoryCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultCategoryDto>>(values);
		}

		public async Task UpdateCategoryAsync(UpdateCategoryDto categoryDto)
		{
			var value = _mapper.Map<Category>(categoryDto);
			await _categoryCollection.FindOneAndReplaceAsync(x=>x.CategoryID==categoryDto.CategoryID,value);
		}
	}
}
