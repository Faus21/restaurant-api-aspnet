namespace RestaurantApp.Models
{
    public class City
    {
        public int CityId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}
