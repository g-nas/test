using test.API.Models.DTO;

namespace test.API.Models.DTO
{
    public class Walk
    {
        public Guid Id { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Region Region { get; set; }
        public WalkDifficulty WalkDifficulty { get; set; }
    }
}
