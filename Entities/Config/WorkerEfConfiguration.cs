using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantApp.Models;
using System.Reflection.Metadata;

namespace RestaurantApp.Entities.IEntityTypeConfig
{
    public class WorkerEfConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.HasKey(e => e.WorkerId).HasName("Worker_pk");

            builder.HasOne(e => e.Person)
                .WithOne(e => e.Worker)
                .HasForeignKey<Worker>(e => e.PersonId)
                .HasConstraintName("Worker_Person")
                .IsRequired();

            builder.ToTable("Worker");

            Worker[] workers =
            {
                new Worker
                {
                    WorkerId = 1,
                    PersonId = 1
                }
            };

            builder.HasData(workers);
        }
    }
}
