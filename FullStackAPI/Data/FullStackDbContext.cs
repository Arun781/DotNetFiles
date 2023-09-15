using FullStackAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStackAPI.Data
{
    public class FullStackDbContext : DbContext
    {
        public FullStackDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AdminModel> admins { get; set; }
        public DbSet<UserModel> users { get; set; }
        public DbSet<VenueModel> venues { get; set; }
        public DbSet<LoginModel> logins { get; set; }
        public DbSet<EventModel> events { get; set; }
        public DbSet<RefereeModel> referees { get; set; }
        public DbSet<TeamModel> teams { get; set; }

    }
}
