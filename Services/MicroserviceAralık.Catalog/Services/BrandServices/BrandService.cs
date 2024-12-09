using AutoMapper;
using MicroserviceAralık.Catalog.Dtos.BrandDtos;
using MicroserviceAralık.Catalog.Entities;
using MicroserviceAralık.Catalog.Settings;
using MongoDB.Driver;

namespace MicroserviceAralık.Catalog.Services.BrandServices;

public class BrandService : IBrandService
{
    private readonly IMongoCollection<Brand> _brandCollection;
    private readonly IMapper _mapper;
    public BrandService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _brandCollection = database.GetCollection<Brand>(databaseSettings.BrandCollectionName);
        _mapper = mapper;
    }
    public async Task CreateBrand(CreateBrandDto dto)
    {
        var newBrand = _mapper.Map<Brand>(dto);
        await _brandCollection.InsertOneAsync(newBrand);
    }

    public async Task DeleteBrand(string id)
    {
        await _brandCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<ResultBrandDto>> GetAllBrands()
    {

        var brands = await _brandCollection.Find(x => true).ToListAsync();
        var mappedValues = _mapper.Map<List<ResultBrandDto>>(brands);
        return mappedValues;
    }

    public async Task<ResultBrandDto> GetBrandById(string id)
    {
        var brand = await _brandCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        var mappedValue = _mapper.Map<ResultBrandDto>(brand);
        return mappedValue;
    }

    public async Task UpdateBrand(UpdateBrandDto dto)
    {
        var updatedBrand = _mapper.Map<Brand>(dto);
        await _brandCollection.ReplaceOneAsync(x => x.Id == dto.Id, updatedBrand);

    }
}
