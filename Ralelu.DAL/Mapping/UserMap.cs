using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ralelu.Domain.Entity;

namespace Ralelu.Domain.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(p => p.Email)
                .IsRequired();

            builder.HasMany(x => x.Posts)
                .WithOne(x => x.User)
                .HasConstraintName("UserId")
                .HasForeignKey(x => x.UserId);
        }
    }
}
