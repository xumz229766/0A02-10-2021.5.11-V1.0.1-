﻿using System;

namespace Motion.LSAps
{
    /// <summary>
    ///     Adlink APS Exception
    /// </summary>
    public class ApsException : Exception
    {
        public ApsException()
        {
        }

        public ApsException(string message)
            : base(message)
        {
        }

        public ApsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}