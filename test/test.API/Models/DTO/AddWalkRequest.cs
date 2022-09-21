namespace test.API.Models.DTO
{
    public class AddWalkRequest
    {
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
    }
}
