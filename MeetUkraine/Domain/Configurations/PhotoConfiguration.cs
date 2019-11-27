using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Configurations
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.ToTable("Photos");

            builder.HasKey(p => p.PhotoId);

            builder.Property(p => p.PhotoUrl).IsRequired();

            builder.Property(p => p.PhotoDate).IsRequired();

            builder.HasOne(p => p.Place).WithOne(p => p.Photo);
        }
    }
}
