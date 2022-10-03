using System.Data.Entity;

namespace Movie_Rental.Models
{
    public class Movie_RentalDB_Content : DbContext
    {
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }

        public DbSet<Genre> Genre { get; set; }
        public DbSet<Movie> Movies { get; set; }

    }
}
