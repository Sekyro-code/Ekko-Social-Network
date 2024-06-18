using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Services.User.Api.Domain.Models;

namespace Services.User.Api.Domain.Data.TypeConfigurations
{
    public class InvitationEntityTypeConfiguration : IEntityTypeConfiguration<Invitation>
    {
        public void Configure(EntityTypeBuilder<Invitation> builder)
        {
            builder.ToTable("UService.Invitation");
            //builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("newid()");
            builder.HasKey(i => new { i.SenderId, i.ReceiverId });

            // Configuration pour la relation avec User (invitations envoyées)
            builder.HasOne(i => i.SenderUser)
                .WithMany(u => u.SentInvitations)
                .HasForeignKey(i => i.SenderId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configuration pour la relation avec User (invitations reçues)
            builder.HasOne(i => i.ReceiverUser) 
                .WithMany(u => u.ReceivedInvitations)
                .HasForeignKey(i => i.ReceiverId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
