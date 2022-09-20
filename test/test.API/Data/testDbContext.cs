using Microsoft.EntityFrameworkCore;
using test.API.Models.Domain;

namespace test.API.Data
{
    public class testDbContext : DbContext
    {
        public testDbContext(DbContextOptions<testDbContext> options): base(options)  
        {

        }

        // Create Region, Walk, WalkDifficulty tables if they don't exist
        public DbSet<Region> Regions { get; set; } 
        public DbSet<Walk> Walks { get; set; } 
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; } 
    }
}
