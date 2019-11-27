using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Configurations
{
    public class PlaceCommentConfiguration:IEntityTypeConfiguration<PlaceComment>
    {
       
        public void Configure(EntityTypeBuilder<PlaceComment> builder)
        {
            builder.ToTable("PlaceComments");

            builder.HasKey(p => p.PlaceCommentId);

            builder.Property(p => p.Comment).IsRequired().HasMaxLength(200);

            builder.HasOne(p => p.User).WithMany(p => p.PlaceComments);

            builder.HasOne(p => p.Place).WithMany(p => p.PlaceComments);
        }
    }
}
