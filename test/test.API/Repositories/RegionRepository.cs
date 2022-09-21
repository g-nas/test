using Microsoft.EntityFrameworkCore;
using test.API.Data;
using test.API.Models.Domain;

namespace test.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly testDbContext testDbContext;

        public RegionRepository(testDbContext testDbContext)
        {
            this.testDbContext = testDbContext;
        }
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await testDbContext.Regions.ToListAsync();
        }
    }
}
