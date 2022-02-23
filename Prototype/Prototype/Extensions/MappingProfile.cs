using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs.Request;
using DTOs.Response;
using Entities;

namespace Prototype.Extensions
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<FlightsResponse, Flight>()            
            .ForMember(Destin => Destin.Origin, Origin => Origin.MapFrom(s => s.departureStation))
            .ForMember(Destin => Destin.Destination, Origin => Origin.MapFrom(s => s.arrivalStation))
            .ForPath(Destin => Destin.Transport.FlightCarrier, o => o.MapFrom(s => s.flightCarrier))
            .ForPath(Destin => Destin.Transport.FlightNumber, o => o.MapFrom(s => s.flightNumber))
            .ReverseMap();
        }
    }
}
