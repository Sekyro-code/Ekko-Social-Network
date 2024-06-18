using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Services.User.Api.Domain.Models;

namespace Services.User.Api.Domain.Data.TypeConfigurations
{
    public class UserRelationEntityTypeConfiguration : IEntityTypeConfiguration<UserRelation>
    {
        public void Configure(EntityTypeBuilder<UserRelation> builder)
        {
            builder.ToTable("UService.UserRelation");
            //builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id).ValueGeneratedOnAdd()
            //    .HasDefaultValueSql("newid()")
            //    .IsRequired();
            builder.HasKey(f => new { f.UserId, f.FriendId });

            // Configuration pour la relation avec User
            builder.HasOne(ur => ur.UserOne)
                .WithMany()
                .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ur => ur.UserTwo)
                .WithMany(u => u.Friendships)
                .HasForeignKey(ur => ur.FriendId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
