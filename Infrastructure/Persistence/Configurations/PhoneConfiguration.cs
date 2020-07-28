using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using DemoProject.Domain.Entities;

namespace DemoProject.Infrastructure.Persistence.Configurations
{
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.Property(o => o.PhoneNumber).IsRequired();

            builder.HasIndex(o => o.PhoneNumber).IsUnique();

            builder.HasOne(o => o.ApplicationUser)
                   .WithMany(o => o.Phones)
                   .HasForeignKey(o => o.ApplicationUserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
