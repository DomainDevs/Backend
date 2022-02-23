using System;
using System.Collections.Generic;

namespace Entities
{
    public class Jorney
    {
        public int JorneyId { get; set; }

        public List<Flight> Flights { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public Double Price { get; set; }
    }
}
