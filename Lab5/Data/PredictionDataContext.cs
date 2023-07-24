using Lab5.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Data
{
    public class PredictionDataContext : DbContext
    {
        public PredictionDataContext(DbContextOptions<PredictionDataContext> options) : base(options)
        {
        }

        // DbSet to hold your Prediction objects
        public DbSet<Prediction> Predictions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define the table name for the Prediction entity
            modelBuilder.Entity<Prediction>().ToTable("Prediction");
        }
    }
}