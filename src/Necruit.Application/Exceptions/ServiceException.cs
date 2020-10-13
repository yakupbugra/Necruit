using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Necruit.Application.Exceptions
{
   public  class ServiceException : Exception
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