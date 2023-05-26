using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace BigBangApi.Models
{
    public class HotelDbContext :DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }



        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Rooms> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       
            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.Rooms)
                .WithOne(r => r.Hotel)
                .HasForeignKey(r => r.Hid);
        }

    }
}
