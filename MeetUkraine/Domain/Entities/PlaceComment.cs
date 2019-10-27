using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class PlaceComment
    {
        public int PlaceCommentId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int PlaceId { get; set; }
        public Place Place { get; set; }

        public string Comment { get; set; }
    }
}
