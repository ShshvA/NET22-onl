namespace DatabaseAccessCodeFirst.Models
{
    public class CoachEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public int? Age { get; set; }

        public List<TeamEntity>? Teams { get; set; } = new List<TeamEntity>();
    }
}
