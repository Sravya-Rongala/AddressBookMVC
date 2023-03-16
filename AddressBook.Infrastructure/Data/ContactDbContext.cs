using AddressBook.Models;
using Microsoft.EntityFrameworkCore;
namespace AddressBook.Data
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options) { }
        public DbSet<ContactModel> ContactDetails  {get; set;} 
    }
}
 