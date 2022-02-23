using System;
using System.Collections.Generic;
using System.Text;

namespace UOW.Interfaces
{
    public interface IUOWAdapter : IDisposable
    {
        IUOWRepository Repositories { get; }
        void SaveChanges();
    }
}
