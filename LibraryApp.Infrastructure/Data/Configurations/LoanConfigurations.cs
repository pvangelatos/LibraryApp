using LibraryApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Infrastructure.Data.Configurations
{
    public class LoanConfigurations : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.Property(t => t.LoanDate).IsRequired();
            builder.HasOne(l => l.Book)
                   .WithMany(b => b.Loans)
                   .HasForeignKey(l => l.BookId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(m => m.Member)
                   .WithMany(m => m.Loans)
                   .HasForeignKey(l => l.MemberId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
