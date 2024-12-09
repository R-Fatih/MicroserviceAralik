using MongoDB.Bson.Serialization.Attributes;

namespace MicroserviceAralık.Catalog.Entities;

public class ProductDetail
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }
    public string ProductId { get; set; }
    public string Description { get; set; }
    public string Information { get; set; }
    [BsonIgnore]
    public Product Product { get; set; }
}
