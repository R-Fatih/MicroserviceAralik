namespace MicroserviceAralık.Discount.Entities;

public class CouponRedemption
{
    public int Id { get; set; }
    public int CouponId { get; set; }
    public string UserId { get; set; }
    public int OrderId { get; set; }
    public DateTime RedemptionDate { get; set; }
    public int DiscountRate { get; set; }


}
