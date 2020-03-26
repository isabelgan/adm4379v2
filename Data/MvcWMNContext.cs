using Microsoft.EntityFrameworkCore;
using WMN.Models;

namespace WMN.Data
{
    public class MvcWMNContext : DbContext
    {
        public MvcWMNContext(DbContextOptions<MvcWMNContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contact { get; set; }
    }
}