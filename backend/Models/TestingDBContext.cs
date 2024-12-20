using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public partial class TestingDBContext : DbContext
    {
        public TestingDBContext() { }

        public TestingDBContext(DbContextOptions<TestingDBContext> options) : base(options) { }

        public virtual DbSet<Pokemon> PokemonsTable { get; set; }
        public virtual DbSet<Region> RegionTable { get; set; }
        public virtual DbSet<Type> TypeTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>(entity =>
            {
                entity.ToTable("PokemonsTable");
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.HasOne(d => d.Region).WithMany(p => p.Pokemons)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK_PokemonsTable_Region");

                entity.HasOne(d => d.Type).WithMany(p => p.Pokemons)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_PokemonsTable_Type");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("RegionTable");
                entity.Property(e => e.RegionName).HasMaxLength(50);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("TypeTable");
                entity.Property(e => e.TypeName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}