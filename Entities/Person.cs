namespace RestaurantApp.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public virtual Client? Client { get; set; }

        public virtual Worker? Worker { get; set; }
    }
}
