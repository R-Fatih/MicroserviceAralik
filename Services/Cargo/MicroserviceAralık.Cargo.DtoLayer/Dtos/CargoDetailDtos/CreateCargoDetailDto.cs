namespace MicroserviceAralık.Cargo.DtoLayer.Dtos.CargoDetailDtos;
public class CreateCargoDetailDto
{
    public int SenderCustomerId { get; set; }
    public int ReceiverCustomerId { get; set; }
    public string Barcode { get; set; }
    public int CompanyId { get; set; }
}
