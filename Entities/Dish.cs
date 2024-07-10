namespace RestaurantApp.Models
{
    public class Dish
    {
        public int DishId { get; set; }

        public string DishName { get; set; }

        public virtual ICollection<OrderDish> OrderDishes { get; set; } = new List<OrderDish>();
    }
}
