using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using AdoNetCore.AseClient;
using Entities;

namespace Repository.Sybase
{
    public class FlightRepository : Repository, IFlightRepository
    {
        public FlightRepository(AseConnection context, AseTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public void Create(Flight model)
        {
            var query = "INSERT INTO Flight (FlightId, Origin, Destination, Price) " +
                "VALUES (@FlightId, @Origin, @Destination, @Price)";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@FlightId", model.FlightId);
            command.Parameters.AddWithValue("@Origin", model.Origin);
            command.Parameters.AddWithValue("@Destination", model.Destination);
            command.Parameters.AddWithValue("@Price", model.Price);
            command.ExecuteScalar();

            //model.Id = Convert.ToInt32(command.ExecuteScalar());
        }

        public Flight Get(int FlightId)
        {
            var command = CreateCommand("SELECT * FROM Flight WHERE FlightId = @id");
            command.Parameters.AddWithValue("@FlightId", FlightId);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new Flight
                {
                    FlightId = Convert.ToInt32(reader["FlightId"]),
                    Origin = Convert.ToString(reader["Origin"]),
                    Destination = Convert.ToString(reader["Destination"]),
                    Price = Convert.ToDouble(reader["Price"])
                };
            };
        }
        public IEnumerable<Flight> GetAll()
        {
            var result = new List<Flight>();

            var command = CreateCommand("SELECT * FROM Flight");

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Flight
                    {
                        FlightId = Convert.ToInt32(reader["FlightId"]),
                        Origin = Convert.ToString(reader["Origin"]),
                        Destination = Convert.ToString(reader["Destination"]),
                        Price = Convert.ToDouble(reader["Price"]),
                    });
                }
            }

            return result;
        }


    }
}
