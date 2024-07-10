using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantApp.Models;

namespace RestaurantApp.Entities.Config
{
    public class RestaurantWorkerEfConfiguration : IEntityTypeConfiguration<RestaurantWorker>
    {
        public void Configure(EntityTypeBuilder<RestaurantWorker> builder)
        {
            builder.HasKey(e => e.RestaurantWorkerId).HasName("RestaurantWorker_pk");

            builder.HasOne(e => e.Worker)
                .WithMany(e => e.RestaurantWorkers)
                .HasForeignKey(e => e.WorkerId)
                .HasConstraintName("RestaurantWorker_Worker");

            builder.HasOne(e => e.Restaurant)
                .WithMany(e => e.RestaurantWorkers)
                .HasForeignKey(e => e.WorkerId)
                .HasConstraintName("RestaurantWorker_Restaurant");

            builder.Property(e => e.HireDate).IsRequired();
            builder.Property(e => e.DismissalDate);

            builder.ToTable("RestaurantWorker");

            RestaurantWorker[] restaurantWorkers =
            {
                new RestaurantWorker
                {
                    RestaurantWorkerId = 1,
                    WorkerId = 1,
                    RestaurantId = 1,
                    HireDate = DateOnly.MinValue,
                    DismissalDate = DateOnly.MaxValue
                },
                new RestaurantWorker
                {
                    RestaurantWorkerId = 2,
                    WorkerId = 1,
                    RestaurantId = 2,
                    HireDate = DateOnly.MinValue
                }
            };

            builder.HasData(restaurantWorkers);
        }
    }
}
