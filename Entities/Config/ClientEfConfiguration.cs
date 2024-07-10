using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantApp.Models;

namespace RestaurantApp.Entities.Config
{
    public class ClientEfConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(e => e.ClientId).HasName("Client_pk");

            builder.HasOne(e => e.Person)
                .WithOne(e => e.Client)
                .HasForeignKey<Client>(e => e.PersonId)
                .HasConstraintName("Client_Person")
                .IsRequired();

            builder.ToTable("Client");

            Client[] clients =
            {
                new Client
                {
                    ClientId = 1,
                    PersonId = 2
                }
            };

            builder.HasData(clients);
        }
    }
}
