using MongoDB.Bson.Serialization.Attributes;

namespace MicroserviceAralık.Catalog.Entities;

public class Product
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public string CategoryId { get; set; }
    public string Description { get; set; }
    [BsonIgnore]
    public Category Category { get; set; }
}
