using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using AdoNetCore.AseClient;
using Entities;

namespace Repository.Sybase
{

    public class TransportRepository : Repository, ITransportRepository
    {
        public TransportRepository(AseConnection context, AseTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public void Create(Transport model)
        {
            var query = "INSERT INTO Transport (TransportId, FlightNumber, FlightCarrier) " +
                "VALUES (@TransportId, @FlightNumber, @FlightCarrier)";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@TransportId", model.TransportId);
            command.Parameters.AddWithValue("@FlightNumber", model.FlightNumber);
            command.Parameters.AddWithValue("@FlightCarrier", model.FlightCarrier);
            command.ExecuteScalar();

            //model.Id = Convert.ToInt32(command.ExecuteScalar());
        }

        public Transport Get(int id)
        {
            var command = CreateCommand("SELECT * FROM Transport WHERE TransportId = @id");
            command.Parameters.AddWithValue("@TransportId", id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new Transport
                {
                    TransportId = Convert.ToInt32(reader["TransportId"]),
                    FlightNumber = Convert.ToString(reader["FlightNumber"]),
                    FlightCarrier = Convert.ToString(reader["FlightCarrier"])
                };
            };
        }
        public IEnumerable<Transport> GetAll()
        {
            var result = new List<Transport>();
            var command = CreateCommand("SELECT * FROM Transport");

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Transport
                    {
                        TransportId = Convert.ToInt32(reader["TransportId"]),
                        FlightNumber = Convert.ToString(reader["FlightNumber"]),
                        FlightCarrier = Convert.ToString(reader["FlightCarrier"])
                    });
                }
            }
            return result;
        }
    }
}
