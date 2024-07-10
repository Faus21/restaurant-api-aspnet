namespace RestaurantApp.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public int Places { get; set; }

        public int CityId { get; set; }
        
        public virtual City City { get; set; }

        public virtual ICollection<RestaurantWorker> RestaurantWorkers { get; set; } = new List<RestaurantWorker>();
    }
}
