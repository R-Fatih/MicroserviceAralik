using AutoMapper;
using MicroserviceAralık.Catalog.Dtos.ProductDetailDtos;
using MicroserviceAralık.Catalog.Entities;
using MicroserviceAralık.Catalog.Settings;
using MongoDB.Driver;

namespace MicroserviceAralık.Catalog.Services.ProductDetailServices;

public class ProductDetailService : IProductDetailService
{
    private readonly IMongoCollection<ProductDetail> _productDetailCollection;
    private readonly IMapper _mapper;
    public ProductDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
        _mapper = mapper;
    }
    public async Task CreateProductDetail(CreateProductDetailDto dto)
    {
        var newProductDetail = _mapper.Map<ProductDetail>(dto);
        await _productDetailCollection.InsertOneAsync(newProductDetail);
    }

    public async Task DeleteProductDetail(string id)
    {
        await _productDetailCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<ResultProductDetailDto>> GetAllProductDetails()
    {

        var productDetails = await _productDetailCollection.Find(x => true).ToListAsync();
        var mappedValues = _mapper.Map<List<ResultProductDetailDto>>(productDetails);
        return mappedValues;
    }

    public async Task<ResultProductDetailDto> GetProductDetailById(string id)
    {
        var productDetail = await _productDetailCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        var mappedValue = _mapper.Map<ResultProductDetailDto>(productDetail);
        return mappedValue;
    }

    public async Task UpdateProductDetail(UpdateProductDetailDto dto)
    {
        var updatedProductDetail = _mapper.Map<ProductDetail>(dto);
        await _productDetailCollection.ReplaceOneAsync(x => x.Id == dto.Id, updatedProductDetail);

    }
}
