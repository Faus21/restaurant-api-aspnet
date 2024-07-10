namespace RestaurantApp.Models
{
    public class Order
    {

        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public int ClientId { get; set; }

        public int WorkerId { get; set; }

        public virtual Worker Worker { get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<OrderDish> OrderDishes { get; set; } = new List<OrderDish>();
    }
}
