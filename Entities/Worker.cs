namespace RestaurantApp.Models
{
    public class Worker
    {

        public int WorkerId { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public virtual ICollection<RestaurantWorker> RestaurantWorkers { get; set; } = new List<RestaurantWorker>();

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
