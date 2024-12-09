using MongoDB.Bson.Serialization.Attributes;

namespace MicroserviceAralık.Catalog.Entities;

public class Brand
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
}
