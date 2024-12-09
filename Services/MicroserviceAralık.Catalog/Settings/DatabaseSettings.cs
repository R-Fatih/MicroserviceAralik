namespace MicroserviceAralık.Catalog.Settings;

public class DatabaseSettings : IDatabaseSettings
{
    public string BrandCollectionName { get; set; }
    public string CategoryCollectionName { get; set; }
    public string ProductCollectionName { get; set; }
    public string ProductDetailCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}
