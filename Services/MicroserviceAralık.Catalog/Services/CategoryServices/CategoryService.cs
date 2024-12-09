using AutoMapper;
using MicroserviceAralık.Catalog.Dtos.CategoryDtos;
using MicroserviceAralık.Catalog.Entities;
using MicroserviceAralık.Catalog.Settings;
using MongoDB.Driver;

namespace MicroserviceAralık.Catalog.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;
    public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        _mapper = mapper;
    }
    public async Task CreateCategory(CreateCategoryDto dto)
    {
        var category = _mapper.Map<Category>(dto);
        await _categoryCollection.InsertOneAsync(category);
    }

    public async Task DeleteCategory(string id)
    {
        await _categoryCollection.DeleteOneAsync(x => x.Id == id)
;
    }

    public async Task<List<ResultCategoryDto>> GetAllCategories()
    {
        var categories = await _categoryCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultCategoryDto>>(categories);
    }

    public async Task<ResultCategoryDto> GetCategoryById(string id)
    {
        var category = await _categoryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        var result = _mapper.Map<ResultCategoryDto>(category);
        return result;
    }

    public async Task UpdateCategory(UpdateCategoryDto dto)
    {
        var category = _mapper.Map<Category>(dto);
        await _categoryCollection.ReplaceOneAsync(x => x.Id == dto.Id, category);

    }
}
