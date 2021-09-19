namespace OLT_FSP.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using OLT_FSP.Data.Models;

    public class OltDbContext : IdentityDbContext
    {
        public OltDbContext(DbContextOptions<OltDbContext> options)
            : base(options)
        {
        }

        public DbSet<Town> Towns { get; set; }
        public DbSet<DataCenter> DataCenters { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<Destination> Destinations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<DataCenter>()
                .HasOne(d => d.Town)
                .WithMany(t => t.DataCenters)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Device>()
                .HasOne(d => d.DataCenter)
                .WithMany(dc => dc.Devices)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Slot>()
                .HasOne(s => s.Device)
                .WithMany(d => d.Slots)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Port>()
                .HasOne(p => p.Slot)
                .WithMany(s => s.Ports)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

    }
}
