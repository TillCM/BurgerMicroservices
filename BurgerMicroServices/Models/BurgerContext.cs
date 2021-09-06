using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BurgerMicroServices.Models
{
    public partial class BurgerContext : DbContext
    {
        public BurgerContext()
        {
        }

        public BurgerContext(DbContextOptions<BurgerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bun> Buns { get; set; }
        public virtual DbSet<Condiment> Condiments { get; set; }
        public virtual DbSet<Patty> Patties { get; set; }
        public virtual DbSet<Topping> Toppings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=VCDHADMHOSLP05\\SQLEXPRESS;Initial Catalog=Burger;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bun>(entity =>
            {
                entity.ToTable("Bun");

                entity.Property(e => e.BunId)
                    .ValueGeneratedNever()
                    .HasColumnName("BunID");

                entity.Property(e => e.BunType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Condiment>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CodimentId).HasColumnName("CodimentID");

                entity.Property(e => e.CondimentType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patty>(entity =>
            {
                entity.ToTable("Patty");

                entity.Property(e => e.PattyId)
                    .ValueGeneratedNever()
                    .HasColumnName("PattyID");

                entity.Property(e => e.PattyType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.HasKey(e => e.ToppingType);

                entity.ToTable("Topping");

                entity.Property(e => e.ToppingType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToppingId).HasColumnName("ToppingID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
