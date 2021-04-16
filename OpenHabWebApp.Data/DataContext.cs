using Microsoft.EntityFrameworkCore;
using OpenHabWebApp.Domain;
using System;

namespace OpenHabWebApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Esp32camImage> Esp32camImages { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Esp32camImage>()
                .ToTable("Esp32camImages")
                .HasKey(x => x.Id);
        }
    }
}
