namespace DatabaseAccessCodeFirst.Models
{
    public class PlayerEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public int? Age { get; set; }

        public decimal? Salary { get; set; } = 0;

        public int? TeamId { get; set; }

        public TeamEntity? Team { get; set; }
    }
}
