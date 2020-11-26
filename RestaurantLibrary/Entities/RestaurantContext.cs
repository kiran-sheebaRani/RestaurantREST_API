using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestaurantLibrary.Entities
{
    public partial class RestaurantContext : DbContext
    {
        public RestaurantContext()
        {
        }

        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RestaurantInfo> RestaurantInfo { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source = restaurant.cldijqelnyn8.us-east-2.rds.amazonaws.com,1433;database=Restaurant;User ID=admin;Password=ColdFusion2.0;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RestaurantInfo>(entity =>
            {
                entity.HasKey(e => e.RestaurantId)
                    .HasName("PK__Restaura__87454CB58944A25A");

                entity.Property(e => e.RestaurantId)
                    .HasColumnName("RestaurantID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RestaurantAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RestaurantName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RestaurantPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RestaurantPopular)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RestaurantRating)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
