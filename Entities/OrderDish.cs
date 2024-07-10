namespace RestaurantApp.Models
{
    public class OrderDish
    {
        public int DishId { get; set; }

        public int OrderId { get; set; }

        public int Quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Dish Dish { get; set; }
    }
}
