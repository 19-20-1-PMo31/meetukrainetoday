using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Configurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("Ratings");

            builder.HasKey(p => p.RatingId);

            builder.HasOne(p => p.User);

            builder.HasOne(p => p.Place).WithMany(p=>p.Ratings);

            builder.Property(p => p.Rate).IsRequired();
        }
    }
}
