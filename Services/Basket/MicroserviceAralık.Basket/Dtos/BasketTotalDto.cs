namespace MicroserviceAralık.Basket.Dtos;

public class BasketTotalDto
{
    public string DiscountCode { get; set; }
    public int DiscountRate { get; set; }
    public List<BasketItemDto> BasketItems { get; set; }
    public decimal TotalPrice { get => BasketItems.Sum(x => (x.Quantity * x.Price)); }
}
