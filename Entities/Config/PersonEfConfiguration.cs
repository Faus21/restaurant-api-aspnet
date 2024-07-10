using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantApp.Models;

namespace RestaurantApp.Entities.Config
{
    public class PersonEfConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(e => e.PersonId).HasName("Person_pk");

            builder.Property(e => e.Name).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Surname).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(50).IsRequired();
            builder.Property(e => e.PhoneNumber).HasMaxLength(10).IsRequired();

            builder.ToTable("Person");

            Person[] people =
            {
                new Person
                {
                    PersonId = 1,
                    Name = "John",
                    Surname = "Example",
                    Email = "john@example.com",
                    PhoneNumber = "1111111111",
                },
                new Person
                {
                    PersonId = 2,
                    Name = "Lola",
                    Surname = "Example",
                    Email = "lola@example.com",
                    PhoneNumber = "1111111112",
                }
            };

            builder.HasData(people);
        }
    }
}
