using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Backend.Data.Entities;

namespace Backend.Data.EntityTypeConfiguration
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //DB setup
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Phone).IsRequired().HasMaxLength(50);
            builder.Property(c => c.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(c => c.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
