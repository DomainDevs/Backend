﻿using System;
using System.Globalization;

namespace Infrastructure.common.Exceptions
{
    public class GlobalException : Exception
    {
        public GlobalException() : base()
        {
        }

        public GlobalException(string message) : base(message)
        {
        }

        public GlobalException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
