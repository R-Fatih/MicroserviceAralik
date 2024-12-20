﻿namespace MicroserviceAralık.Inventory.Models;

public class CreateOrderDetailCommand
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductAmount { get; set; }
    public decimal TotalPrice { get; set; }
    public int OrderingId { get; set; }
    public bool StockStatus { get; set; }
}
