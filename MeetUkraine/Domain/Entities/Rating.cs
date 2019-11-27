using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Rating
    {
        public int RatingId { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int PlaceId { get; set; }
        public Place Place { get; set; }

        public int Rate { get; set; }

    }
}
