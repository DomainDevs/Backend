using System;
using System.Collections.Generic;
using System.Text;
using AdoNetCore.AseClient;

namespace Repository.Sybase
{
    public abstract class Repository
    {
        
        protected AseConnection _context;
        protected AseTransaction _transaction;

        protected AseCommand CreateCommand(string query)
        {
            return new AseCommand(query, _context, _transaction);
        }
    }
}
