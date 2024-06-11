namespace VBS_Api.Models;

public class Inventory {
    public int FoodId { get; set; }
    public string Name { get; set; }
    public string PhotoUrl { get; set; }
    public int GroupId { get; set; }
    public int SubgroupId { get; set; }
    public int Quantity { get; set; }
    public DateTime StockDate { get; set; }
    public DateTime ExpiryDate { get; set; }
}