namespace MicroserviceAralık.Cargo.EntityLayer.Concrete;
public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<CargoDetail> CargoDetails { get; set; }
}
