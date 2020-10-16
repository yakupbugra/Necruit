using System;

namespace Necruit.Application.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException()
            : base("An error occured in service layer")
        {
        }

        public ServiceException(string message)
            : base(message)
        {
        }
    }
}