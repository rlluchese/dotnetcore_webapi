using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ralelu.Domain.Entity;

namespace Ralelu.Domain.Mapping
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("post");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Text)
                .HasColumnName("Text")
                .IsRequired();

            builder.Property(p => p.Title)
                .HasMaxLength(200);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Posts)
                .HasConstraintName("UserId")
                .HasForeignKey(x => x.UserId);
        }
    }
}
