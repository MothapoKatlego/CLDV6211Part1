using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EventVenue_KM.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=EventDBContent")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .Property(e => e.EventTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Venue>()
                .Property(e => e.VenueName)
                .IsUnicode(false);

            modelBuilder.Entity<Venue>()
                .Property(e => e.VenueAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Venue>()
                .Property(e => e.ImageURL)
                .IsUnicode(false);

            modelBuilder.Entity<Venue>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Venue)
                .WillCascadeOnDelete(false);
        }
    }
}
