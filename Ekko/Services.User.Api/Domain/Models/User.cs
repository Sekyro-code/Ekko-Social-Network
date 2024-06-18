using Common.Api.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Services.User.Api.Domain.Models
{
    public class User : IdentityUser<Guid>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public bool Gender { get; set; } = true;
        public bool Validate { get; set; } = false;
        public int? Notification { get; set; }
        public string? Biography { get; set; }
        public string? Country { get; set; }       
        public string? Picture { get; set; }
        public bool Private { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public ICollection<UserRelation> Friendships { get; set; }
        public ICollection<Invitation> SentInvitations { get; set; } = new List<Invitation>();
        public ICollection<Invitation> ReceivedInvitations { get; set; } = new List<Invitation>();

        public User()
        {

        }

    }

}
