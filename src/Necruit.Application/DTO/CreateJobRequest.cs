using Necruit.Domain.Entities;
using Necruit.Application.Mapping;

namespace Necruit.Application.Request
{
    public class CreateJobRequest:MapTo<Job>
    {
        public string Title { get; set; }
        public string Definition { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
    }
}