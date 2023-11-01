using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL
{
    public class Context : DbContext
    {
        public DbSet<Plant> Plants { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
        }
    }
}
