﻿using Lab4.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Data
{
    public class SportsDbContext : DbContext
    {
        public SportsDbContext(DbContextOptions<SportsDbContext> options) : base(options)
        {
        }

        public DbSet<Fan> Fans { get; set; }
        public DbSet<SportClub> SportClubs { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Fan>().ToTable("Fan");
            modelBuilder.Entity<SportClub>().ToTable("SportClub");

            modelBuilder.Entity<Subscription>()
                .HasKey(s => new { s.FanId, s.SportClubId });

            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.Fan)
                .WithMany(f => f.Subscriptions)
                .HasForeignKey(s => s.FanId);

            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.SportClub)
                .WithMany(sc => sc.Subscriptions)
                .HasForeignKey(s => s.SportClubId);
        }
    }
}
