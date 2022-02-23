using System;
using System.Collections.Generic;

namespace Entities
{
    public class Flight
    {
        public int FlightId { get; set; }

        public Transport Transport { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public Double Price { get; set; }
    }
}
