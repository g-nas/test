using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.API.Data;
using test.API.Models.Domain;

namespace test.API.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly testDbContext testDbContext;

        public WalkDifficultyRepository(testDbContext testDbContext)
        {
            this.testDbContext = testDbContext;
        }

        public async Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = Guid.NewGuid();

            await testDbContext.WalkDifficulty.AddAsync(walkDifficulty);
            await testDbContext.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<WalkDifficulty> DeleteAsync(Guid id)
        {
            var walkDifficulty = await testDbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);
            if (walkDifficulty == null)
            {
                return null;
            }
            testDbContext.WalkDifficulty.Remove(walkDifficulty);
            await testDbContext.SaveChangesAsync();
            return walkDifficulty;

        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await testDbContext.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty> GetAsync(Guid id)
        {
            return await testDbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walkDifficulty)
        {
            var existingWalkDifficulty = await testDbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalkDifficulty == null)
            {
                return null;
            }
            existingWalkDifficulty.Code = walkDifficulty.Code;
            await testDbContext.SaveChangesAsync();
            return existingWalkDifficulty;
        }

    }
}
