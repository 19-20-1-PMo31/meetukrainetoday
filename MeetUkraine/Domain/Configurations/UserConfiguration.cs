using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasMany(u => u.PlaceStatuses).WithOne(p => p.User).HasForeignKey(k=>k.UserId);

            builder.HasMany(u => u.PlaceComments).WithOne(p => p.User).HasForeignKey(k => k.UserId);

            builder.Property(p => p.FirstName).IsRequired();

            builder.Property(p => p.LastName).IsRequired();
        }
    }
}
