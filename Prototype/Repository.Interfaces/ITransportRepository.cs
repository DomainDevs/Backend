
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    using Entities;
    using Repository.Interfaces.Actions;

    public interface ITransportRepository :
    IReadRepository<Transport, int>, ICreateRepository<Transport>
    {

    }
}
