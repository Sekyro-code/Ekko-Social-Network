namespace Services.User.Api.Domain.Models
{
    public class Invitation
    {
        //public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public InvitationStatus Status { get; set; }
        public User SenderUser { get; set; }
        public User ReceiverUser { get; set; }
    }

    public enum InvitationStatus
    {
        Pending,
        Accepted,
        Rejected
    }

}
