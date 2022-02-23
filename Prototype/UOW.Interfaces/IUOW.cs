using System;
using System.Collections.Generic;
using System.Text;

namespace UOW.Interfaces
{
    public interface IUOW
    {
        IUOWAdapter Create();
    }
}
