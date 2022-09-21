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

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await testDbContext.AddAsync(region);
            await testDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            // Get the region
            var region = await testDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null)
            {
                return null;
            }

            // Delete the region
            testDbContext.Regions.Remove(region);
            await testDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await testDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
            return await testDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            // Get the related region
            var existingRegion = await testDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            
            // Update the region
            existingRegion.Area = region.Area;
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;

            await testDbContext.SaveChangesAsync();
            return existingRegion;

        }
    }
}
