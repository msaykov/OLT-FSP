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
        public DbSet<Target> Targets { get; set; }

        public DbSet<Position> Positions { get; set; }
        public DbSet<Splitter> Splitters { get; set; }


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

            builder
                .Entity<Position>()
                .HasOne(p => p.Splitter)
                .WithMany(s => s.Positions)
                .OnDelete(DeleteBehavior.Restrict);

            //builder
            //    .Entity<Position>()
            //    .HasOne(p => p.D)
            //    .WithMany(d => d.Paths)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder
            //      .Entity<Port>()
            //      .HasOne(p => p.Splitter)
            //      .WithOne(s => s.Port)
            //      .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Target>()
                .HasMany(p => p.Ports)
                .WithMany(d => d.Targets);
                //.OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(builder);
        }

    }
}
