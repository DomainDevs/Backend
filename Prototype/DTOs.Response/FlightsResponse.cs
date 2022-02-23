using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Response
{
    public class FlightsResponse
    {
        public string departureStation { get; set; }
        public string arrivalStation { get; set; }
        public string flightCarrier { get; set; }
        public string flightNumber { get; set; }
        public Double Price { get; set; }
    }
}
