using System;
using System.Collections.Generic;
using System.Text;
using UOW.Interfaces;
using AdoNetCore.AseClient;

namespace UOW.Sybase
{
    public class UOWSybaseAdapter : IUOWAdapter
    {
        private AseConnection _context { get; set; }
        private AseTransaction _transaction { get; set; }
        public IUOWRepository Repositories { get; set; }

        public UOWSybaseAdapter(string connectionString)
        {
                _context = new AseConnection(connectionString);
                _context.Open();

                _transaction = _context.BeginTransaction();

                Repositories = new UOWSybaseRepository(_context, _transaction);
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }

            if (_context != null)
            {
                _context.Close();
                _context.Dispose();
            }

            Repositories = null;
        }

        public void SaveChanges()
        {
            _transaction.Commit();
        }

    }
}
