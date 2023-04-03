namespace Order.Common
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public CarMake Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}
