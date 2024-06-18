using System.ComponentModel.DataAnnotations.Schema;

namespace Services.User.Api.Domain.Models
{
    public class UserRelation
    {
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public User UserOne { get; set; }
        public User UserTwo { get; set; }

    }
}
