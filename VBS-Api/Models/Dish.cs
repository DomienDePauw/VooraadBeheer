namespace VBS_Api.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string Requirements { get; set; }
        public string QuantityPer100GramAmount { get; set; }
        public string UnitInStock { get; set; }
        public int GroupId { get; set; }
        public int SubgroupId { get; set; }
    }
}
