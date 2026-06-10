using LibraryApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Infrastructure.Data.Configurations
{
    public class MemberConfigurations : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(t => t.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(t => t.LastName).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Email).IsRequired().HasMaxLength(100);
            builder.HasIndex(t => t.Email).IsUnique();
            builder.Property(t => t.Phone).HasMaxLength(20);
            builder.Property(t => t.IsActive).HasDefaultValue(true);
        }
    }
}
