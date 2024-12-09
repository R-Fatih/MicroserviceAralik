using AutoMapper;
using MicroserviceAralık.Catalog.Dtos.ProductDtos;
using MicroserviceAralık.Catalog.Entities;
using MicroserviceAralık.Catalog.Settings;
using MongoDB.Driver;

namespace MicroserviceAralık.Catalog.Services.ProductServices;

public class ProductService : IProductService
{
    private readonly IMongoCollection<Product> _productCollection;
    private readonly IMapper _mapper;
    public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        _mapper = mapper;
    }
    public async Task CreateProduct(CreateProductDto dto)
    {
        var product = _mapper.Map<Product>(dto);
        await _productCollection.InsertOneAsync(product);
    }

    public async Task DeleteProduct(string id)
    {
        await _productCollection.DeleteOneAsync(x => x.Id == id)
;
    }

    public async Task<List<ResultProductDto>> GetAllProducts()
    {
        var products = await _productCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductDto>>(products);
    }

    public async Task<ResultProductDto> GetProductById(string id)
    {
        var product = await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        var result = _mapper.Map<ResultProductDto>(product);
        return result;
    }

    public async Task UpdateProduct(UpdateProductDto dto)
    {
        var product = _mapper.Map<Product>(dto);
        await _productCollection.ReplaceOneAsync(x => x.Id == dto.Id, product);

    }
}
