namespace VBS_FrontEnd.Models {
    public class DishWithNames {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public List<string> Requirements { get; set; }
        public List<int> QuantityPer100GramAmount { get; set; }
        public string UnitInStock { get; set; }
        public string GroupName { get; set; }
        public string SubgroupName { get; set; }
    }
}