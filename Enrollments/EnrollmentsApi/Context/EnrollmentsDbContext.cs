
using EnrollmentsApi.Models;
using Microsoft.EntityFrameworkCore;
namespace EnrollmentsApi.Context
{
    public class EnrollmentsDbContext: DbContext
    {
        public EnrollmentsDbContext(DbContextOptions<EnrollmentsDbContext> options) : base(options) { }

        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}
