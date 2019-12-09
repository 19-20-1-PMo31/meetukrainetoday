using Domain.Configurations;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class MeetUkraineContext:IdentityDbContext<User>
    {
        public DbSet<Place> Places { get; set; }
        //public DbSet<string> Places { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<PlaceComment> PlaceComments { get; set; }

        public DbSet<PlaceStatus> PlaceStatuses { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public MeetUkraineContext() { }

        public MeetUkraineContext(DbContextOptions<MeetUkraineContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AddressConfiguration());

            builder.ApplyConfiguration(new PhotoConfiguration());

            builder.ApplyConfiguration(new PlaceCommentConfiguration());

            builder.ApplyConfiguration(new PlaceConfiguration());

            builder.ApplyConfiguration(new PlaceStatusConfiguration());

            builder.ApplyConfiguration(new RatingConfiguration());

            builder.ApplyConfiguration(new UserConfiguration());

        }
    }
}
