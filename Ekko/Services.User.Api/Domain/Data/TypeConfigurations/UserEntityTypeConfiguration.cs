using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Services.User.Api.Domain.Data.TypeConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<Models.User>
    {
        public void Configure(EntityTypeBuilder<Models.User> builder)
        {
            builder.ToTable("UService.Users");
            builder.HasKey(u => u.Id);
            builder.Property(u =>u.Id).ValueGeneratedOnAdd()
                .HasDefaultValueSql("newid()")
                .IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();
            
        }
    }
}
