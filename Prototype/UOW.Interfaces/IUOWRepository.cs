using Repository.Interfaces;

namespace UOW.Interfaces
{
    public interface IUOWRepository
    {
        IFlightRepository FlightRepository { get; }

        ITransportRepository TransportRepository { get; }
    }
}
