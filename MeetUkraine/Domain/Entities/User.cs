using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class User:IdentityUser
    {
        public string  FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<PlaceStatus> PlaceStatuses { get; set; }

        public ICollection<PlaceComment> PlaceComments { get; set; }
    }
}
