using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Configurations
{
    public class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.ToTable("Places");

            builder.HasKey(p => p.PlaceId);

            builder.Property(p => p.PlaceName).IsRequired();

            builder.HasOne(p => p.Address);

            builder.HasMany(p => p.Ratings).WithOne(p => p.Place).HasForeignKey(p=>p.PlaceId);

            builder.HasMany(p => p.PlaceComments).WithOne(p => p.Place).HasForeignKey(p => p.PlaceId);

            builder.HasOne(p => p.Photo).WithOne(p => p.Place);

            builder.Property(p => p.Longtitude).IsRequired();

            builder.Property(p => p.Latitude).IsRequired();

        }

    }
}
