namespace MicroserviceAralık.Cargo.EntityLayer.Concrete;
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string UserCustomerId { get; set; }
    public List<CargoDetail> SentCargoDetails { get; set; }
    public List<CargoDetail> ReceivedCargoDetails { get; set; }
}
