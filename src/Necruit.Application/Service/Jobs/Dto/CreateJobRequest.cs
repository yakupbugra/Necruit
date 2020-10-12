using Necruit.Application.Mapping;
using Necruit.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Necruit.Application.Service.Jobs.Dto
{
    public class CreateJobRequest : MapTo<Job>
    {
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [Required]
        [MaxLength(4000)]
        public string Definition { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}