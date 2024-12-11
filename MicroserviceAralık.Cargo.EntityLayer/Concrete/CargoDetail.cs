namespace MicroserviceAralık.Cargo.EntityLayer.Concrete;
public class CargoDetail
{
    public int Id { get; set; }
    public int SenderCustomerId { get; set; }
    public int ReceiverCustomerId { get; set; }
    public string Barcode { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public Customer SenderCustomer { get; set; }
    public Customer ReceiverCustomer { get; set; }
}
