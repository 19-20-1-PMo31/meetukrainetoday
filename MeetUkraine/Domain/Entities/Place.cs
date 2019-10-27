using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Place
    {
        public int PlaceId { get; set; }

        public string PlaceName { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public ICollection<Rating> Ratings { get; set; }
        public ICollection<PlaceComment> PlaceComments { get; set; }

        public double Longtitude { get; set; }

        public double Latitude { get; set; }

        public int? PhotoId { get; set; }
        public Photo Photo { get; set; }
    }
}
