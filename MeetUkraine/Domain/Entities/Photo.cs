using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Photo
    {
        public int PhotoId { get; set; }

        public string PhotoUrl { get; set; }

        public Place Place { get; set; }

        public DateTime PhotoDate { get; set; }
    }
}
