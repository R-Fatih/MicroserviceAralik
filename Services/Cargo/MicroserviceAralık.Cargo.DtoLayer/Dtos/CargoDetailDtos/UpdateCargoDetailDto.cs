namespace MicroserviceAralık.Cargo.DtoLayer.Dtos.CargoDetailDtos;
public class UpdateCargoDetailDto
{
    public int Id { get; set; }
    public int SenderCustomerId { get; set; }
    public int ReceiverCustomerId { get; set; }
    public string Barcode { get; set; }
    public int CompanyId { get; set; }
}
