using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Configurations
{
    public class PlaceStatusConfiguration : IEntityTypeConfiguration<PlaceStatus>
    {

        public void Configure(EntityTypeBuilder<PlaceStatus> builder)
        {
            builder.ToTable("PlaceStatuses");

            builder.HasKey(p => p.PlaceStatusId);

            builder.HasOne(p => p.User).WithMany(u=>u.PlaceStatuses);

            builder.HasOne(p => p.Place);

            builder.Property(p => p.Status).IsRequired();
        }
    }
}
