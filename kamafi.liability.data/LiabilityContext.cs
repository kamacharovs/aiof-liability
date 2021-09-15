using System;

using Microsoft.EntityFrameworkCore;

namespace kamafi.liability.data
{
    public class LiabilityContext : DbContext
    {
        public readonly ITenant Tenant;

        public virtual DbSet<LiabilityType> LiabilityTypes { get; set; }
        public virtual DbSet<Liability> Liabilities { get; set; }

        public LiabilityContext(DbContextOptions<LiabilityContext> options, ITenant tenant)
            : base(options)
        {
            Tenant = tenant ?? throw new ArgumentNullException(nameof(tenant));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("liability");

            modelBuilder.Entity<LiabilityType>(e =>
            {
                e.ToTable(Keys.Entity.LiabilityType);

                e.HasKey(x => x.Name);

                e.Property(x => x.Name).HasSnakeCaseColumnName().HasMaxLength(100).IsRequired();
                e.Property(x => x.PublicKey).HasSnakeCaseColumnName().IsRequired();
            });
        }
    }
}