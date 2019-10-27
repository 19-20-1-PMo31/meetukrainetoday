using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public enum Status{
        Visited,
        Interested,
        NotInterested
    }

    public class PlaceStatus
    {
        public int PlaceStatusId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int PlaceId { get; set; }
        public Place Place { get; set; }

        public Status Status { get; set; }
    }
}
