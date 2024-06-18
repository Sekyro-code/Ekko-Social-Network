namespace Services.User.Api.Domain.Models
{
    public class Friend
    {
        public Guid Id { get; set; }
        public required string UserName { get; set; }
        public string? Picture { get; set; } = string.Empty;
        public string? Biography { get; set; }
        public string? Country { get; set; }
        public bool Private { get; set; }
        public required DateTime Birthday { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
