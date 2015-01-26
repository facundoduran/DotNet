using AdvancedTechniques.UP.Business.Model;
using AdvancedTechniques.UP.Common.Catalogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTechniques.UP.Persistence.Sql
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Table> Tables { get; set; }

        public RestaurantDbContext() : base(ConnectionStringCatalog.ConnectionStringKey) 
        {
            Database.SetInitializer<RestaurantDbContext>(new DropCreateDatabaseIfModelChanges<RestaurantDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasKey(x => x.BookingId);

            modelBuilder.Entity<Booking>()
                .Property(x => x.BookingId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Table>().HasKey(x => x.TableId);

            modelBuilder.Entity<Table>()
                .Property(x => x.TableId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Table>()
                .HasMany(t => t.Bookings)
                .WithRequired(t => t.Table)
                .HasForeignKey(b => b.TableId);

            base.OnModelCreating(modelBuilder);            
        }
    }
}
