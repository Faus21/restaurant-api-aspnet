namespace RestaurantApp.Models
{
    public class RestaurantWorker
    {

        public int RestaurantWorkerId { get; set; }

        public int RestaurantId { get; set; }

        public int WorkerId { get; set; }

        public DateOnly HireDate { get; set; }

        public DateOnly? DismissalDate { get; set; }

        public virtual Worker Worker { get; set; }

        public virtual Restaurant Restaurant { get; set; }

    }
}
