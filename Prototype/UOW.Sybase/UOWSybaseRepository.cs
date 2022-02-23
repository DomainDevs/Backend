

using Repository.Interfaces;
using Repository.Sybase;
using AdoNetCore.AseClient;
using UOW.Interfaces;

namespace UOW.Sybase
{
    public class UOWSybaseRepository : IUOWRepository
    {
        public IFlightRepository FlightRepository { get; }
        public ITransportRepository TransportRepository { get; }

        public UOWSybaseRepository(AseConnection context, AseTransaction transaction)
        {
            FlightRepository = new FlightRepository(context, transaction);
            TransportRepository = new TransportRepository(context, transaction);
        }
    }
}
