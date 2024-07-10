namespace RestaurantApp.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
