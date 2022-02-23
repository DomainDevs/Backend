using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Repository.Interfaces.Actions;

namespace Repository.Interfaces
{
    public interface IFlightRepository : 
        IReadRepository<Flight, int>, ICreateRepository<Flight>
    {

    }
}
