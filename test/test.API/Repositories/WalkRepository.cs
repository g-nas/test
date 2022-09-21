using Microsoft.EntityFrameworkCore;
using test.API.Data;
using test.API.Models.Domain;

namespace test.API.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly testDbContext testDbContext;

        public WalkRepository(testDbContext testDbContext)
        {
            this.testDbContext = testDbContext;
        }
        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await testDbContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty) // Include the navigation properties of each Walk
                .ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid id)
        {
            return await testDbContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();
            await testDbContext.AddAsync(walk);
            await testDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
            // Get the related walk
            var existingWalk = await testDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null)
            {
                return null;
            }

            // Update the walk
            existingWalk.Length = walk.Length;
            existingWalk.WalkDifficultyId = walk.WalkDifficultyId;
            existingWalk.Name = walk.Name;
            existingWalk.RegionId = walk.RegionId;

            await testDbContext.SaveChangesAsync();
            return existingWalk;

        }
        public async Task<Walk> DeleteAsync(Guid id)
        {
            // Get the walk
            var walk = await testDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (walk == null)
            {
                return null;
            }

            // Delete the walk
            testDbContext.Walks.Remove(walk);
            await testDbContext.SaveChangesAsync();
            return walk;
        }
    }
}
