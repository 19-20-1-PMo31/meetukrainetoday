﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Address
    {
        public int AddressId { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Building { get; set; }
    }
}
