using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantApp.Models;

namespace RestaurantApp.Entities.Config
{
    public class OrderEfConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.OrderId).HasName("Order_pk");

            builder.HasOne(e => e.Worker)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.OrderId)
                .HasConstraintName("Order_Worker");

            builder.HasOne(e => e.Client)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.OrderId)
                .HasConstraintName("Order_Client");

            builder.Property(e => e.OrderDate).IsRequired();

            builder.ToTable("Order");

            Order[] orders =
            {
                new Order
                {
                    OrderId = 1,
                    OrderDate = DateTime.Now.ToUniversalTime(),
                    ClientId = 1,
                    WorkerId = 1
                }
            };

            builder.HasData(orders);
        }
    }
}
