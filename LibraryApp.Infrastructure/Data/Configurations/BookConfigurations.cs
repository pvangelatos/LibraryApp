using LibraryApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LibraryApp.Infrastructure.Data.Configurations
{
    public class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(t => t.Title).IsRequired().HasMaxLength(200);
            builder.Property(t => t.Author).IsRequired().HasMaxLength(100);
            builder.Property(t => t.ISBN).HasMaxLength(20);
            builder.HasIndex(t => t.ISBN).IsUnique();
            builder.Property(t => t.IsAvailable).HasDefaultValue(true);
        }
    }
}
