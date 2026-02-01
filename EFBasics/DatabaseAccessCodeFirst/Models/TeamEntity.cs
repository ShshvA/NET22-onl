namespace DatabaseAccessCodeFirst.Models
{
    public class TeamEntity
    {
        public int Id { get; set; }

        public string TeamName { get; set; } = null!;

        public DateOnly? FoundingDate { get; set; }

        public List<PlayerEntity>? Players { get; set; } = new List<PlayerEntity>();

        public int? CoachId { get; set; }

        public CoachEntity? Coach {  get; set; }
    }
}
