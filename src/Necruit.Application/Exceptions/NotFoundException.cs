using System;

namespace Necruit.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(int id)
            : base($"Item not found by id{id}")
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}